using System.Collections.Generic;

namespace Vote.Core.Interfaces.Model
{
    public interface IModalidade : IBaseModel
    {
        string Descricao { get; set; }
        string Titulo { get; set; }
        ICollection<IRestaurante> Restaurantes { get; set; }
    }
}