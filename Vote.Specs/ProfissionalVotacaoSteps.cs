using System;
using System.Globalization;
using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Vote.DAO;
using Vote.Roles;
using Vote.Roles.Restaurant;

namespace Vote.Specs
{
    [Binding]
    public class ProfissionalVotacaoSteps
    {
        private readonly VoteEF _db = new VoteEF();
        private string Result { get; set; }
        private int IdFuncionario { get; set; }
        private int IdRestaurante { get; set; }

        [Given(@"Funcionario (.*) esta votando em (.*)")]
        public void GivenFuncionarioestavotandoem(int idFunc, int idRest, Table table)
        {
            if (RestauranteRoles.ValidaRestaurante(_db, idRest))
                IdRestaurante = idRest;
            if (FuncionarioRoles.ValidaFuncionario(_db, idFunc))
                IdFuncionario = idFunc;
        }

        [When(@"Votar funcionario (.*) restaurante (.*) no dia ""(.*)""")]
        public void Votarfuncionariorestaurantenodia(int idFunc, int idRest, string dataVoto)
        {
            _db.Database.BeginTransaction();
            var dataVotacao = DateTime.ParseExact(dataVoto, "dd/MM/yyyy HH:mm:ss", new CultureInfo("pt-BR"));
            Result = VoteRoles.Votar(_db, IdFuncionario, IdRestaurante, dataVotacao);
            _db.Database.CurrentTransaction.Rollback();
        }

        [Then(@"A resposta deve ser ""(.*)""")]
        public void ThenARespostaDeveSer(string resultadoEsperado)
        {
            Assert.AreEqual(resultadoEsperado, Result);
        }

    }
}
