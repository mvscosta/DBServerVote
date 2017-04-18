using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using Vote.DAO;

namespace Vote.Roles
{

    public class VoteRoles
    {
        public static int VotosComputados(VoteEF db, DateTime dataHoraResultado)
        {
            if (db == null)
                db = new VoteEF();

            return db.Votos.Count(vt => DbFunctions.TruncateTime(vt.DataVoto) == DbFunctions.TruncateTime(dataHoraResultado));
        }

        /// <summary>
        /// Valida critérios para votação e salva voto se restrições satisfeitas
        ///     Horario maximo para votação 11:30
        ///     Funcionario Ativo
        ///     Id Restaurante existir
        ///     Restaurante não foi escolhido na semana do voto
        /// </summary>
        /// <param name="db"></param>
        /// <param name="idFuncionario"></param>
        /// <param name="idRestaurante"></param>
        /// <param name="dataHoraVotacao"></param>
        /// <returns></returns>
        public static string Votar(VoteEF db, int idFuncionario, int idRestaurante, DateTime dataHoraVotacao)
        {
            if (!ValidaLimiteHoraVoto(dataHoraVotacao))
                return "Prazo de votação encerrado para o hoje. Aguardamos seu voto amanhã!";

            if (db == null)
                db = new VoteEF();

            if (db.Votos.Any(vt => DbFunctions.TruncateTime(vt.DataVoto) == DbFunctions.TruncateTime(dataHoraVotacao) 
                                && vt.IdFuncionario == idFuncionario))
                return "Funcionário já votou hoje!";

            var funcionario = db.Funcionarios.Find(idFuncionario);
            if (funcionario == null || !funcionario.Ativo)
                return "Você não pode votar!";

            var restaurante = db.Restaurantes.Find(idRestaurante);
            if (restaurante == null)
                return "Restaurante inválido!";

            if (!ValidaRestauranteVotacaoSemanal(db, idRestaurante, dataHoraVotacao.AddDays(-1)))
                return "Este restaurante já foi votado esta semana!";

            db.Votos.Add(new Voto()
            {
                DataVoto = dataHoraVotacao,
                IdRestaurante = idRestaurante,
                IdFuncionario = idFuncionario
            });
            int change = db.SaveChanges();

            return change > 0 ? "Voto computado!" : "Não foi possível salvar seu voto. Tenta novamente.";
        }

        private static bool ValidaLimiteHoraVoto(DateTime dataHoraVotacao)
        {
            if ((dataHoraVotacao.Hour >= 11 && dataHoraVotacao.Minute > 30) || dataHoraVotacao.Hour > 11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Verifica se o restaurante já foi escolhido esta na semana da votação
        /// </summary>
        /// <param name="db"></param>
        /// <param name="idRestaurante"></param>
        /// <param name="dataHoraVotacao"></param>
        /// <returns>retorna true se não foi escolhido ainda</returns>
        private static bool ValidaRestauranteVotacaoSemanal(VoteEF db, int idRestaurante, DateTime dataHoraVotacao)
        {
            if (db == null)
                db = new VoteEF();

            //var semanaAno = GetWeekNumber((dataHoraVotacao));
            var diaSemana = (int)dataHoraVotacao.DayOfWeek;
            //domingo == 0;
            var inicioSemana = dataHoraVotacao.AddDays(-1 * (diaSemana - 1)).Date;

            while (inicioSemana < dataHoraVotacao)
            {
                var rest = RestauranteMaisVotado(db, inicioSemana);
                if (rest?.Id == idRestaurante)
                    return false;
                inicioSemana = inicioSemana.AddDays(1);
            }

            return true;
        }
        /// <summary>
        /// Retorna restaurante vencedor da votação do dia
        /// </summary>
        /// <param name="db"></param>
        /// <param name="dataHoraResultado"></param>
        /// <returns></returns>
        public static Restaurante ResultadoRestauranteVencedor(VoteEF db, DateTime dataHoraResultado)
        {
            if (db == null)
                db = new VoteEF();

            if (!ValidaLimiteHoraVoto(dataHoraResultado))
            {
                return RestauranteMaisVotado(db, dataHoraResultado);
            }
            return null;
        }

        /// <summary>
        /// Retorna o restaurante mais votado
        /// </summary>
        /// <param name="db"></param>
        /// <param name="dataHoraResultado"></param>
        /// <returns></returns>
        private static Restaurante RestauranteMaisVotado(VoteEF db, DateTime dataHoraResultado)
        {
            if (db == null)
                db = new VoteEF();

            var votosDia = db.Votos.Include("Restaurante")
                .Where(
                    v => DbFunctions.TruncateTime(v.DataVoto) == DbFunctions.TruncateTime(dataHoraResultado.Date));
            var votosRestaurantes = votosDia.GroupBy(v => v.Restaurante)
                .Select(r => new { Restaurante = r.Key, QtdeVotos = r.Count() })
                .OrderByDescending(g => g.QtdeVotos);
            if (votosRestaurantes.Any())
            {
                return votosRestaurantes.First().Restaurante;
            }
            return null;
        }

        private static int GetWeekNumber(DateTime data)
        {
            var ciCurr = CultureInfo.CurrentCulture;
            return ciCurr.Calendar.GetWeekOfYear(data, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
