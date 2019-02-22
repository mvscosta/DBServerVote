using System.Collections.Generic;

namespace Vote.Core.Interfaces.Model
{
    public interface IRestaurante : IBaseModel
    {
        bool Ativo { get; set; }
        ICategoria Categoria { get; set; }
        decimal? DistanciaMedia { get; set; }
        string Endereco { get; set; }
        int IdCategoria { get; set; }
        int IdModalidade { get; set; }
        IModalidade Modalidade { get; set; }
        string Nome { get; set; }
        decimal? ValorMedio { get; set; }
    }
}