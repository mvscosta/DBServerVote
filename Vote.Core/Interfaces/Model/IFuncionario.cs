using System.Collections.Generic;

namespace Vote.Core.Interfaces.Model
{
    public interface IFuncionario: IBaseModel
    {
        bool Administrador { get; set; }
        bool Ativo { get; set; }
        string Nome { get; set; }
        string Username { get; set; }
        ICollection<IVoto> Votos { get; set; }
    }
}