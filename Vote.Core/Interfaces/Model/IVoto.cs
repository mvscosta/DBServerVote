using System;

namespace Vote.Core.Interfaces.Model
{
    public interface IVoto : IBaseModel
    {
        DateTime DataVoto { get; set; }
        IFuncionario Funcionario { get; set; }
        int IdFuncionario { get; set; }
        int IdRestaurante { get; set; }
        IRestaurante Restaurante { get; set; }
    }
}