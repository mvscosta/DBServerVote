using System.Data.Entity;
using Vote.Core.Interfaces.Model;

namespace Vote.Core.Interfaces.DAO
{
    public interface IVoteContext
    {
        IDbSet<ICategoria> Categorias { get; set; }
        IDbSet<IFuncionario> Funcionarios { get; set; }
        IDbSet<IModalidade> Modalidades { get; set; }
        IDbSet<IRestaurante> Restaurantes { get; set; }
        IDbSet<IVoto> Votos { get; set; }
    }
}