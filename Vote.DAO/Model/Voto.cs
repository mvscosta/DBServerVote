namespace Vote.DAO
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using Vote.Core.Interfaces.Model;

    public partial class Voto : IVoto
    {
        IFuncionario IVoto.Funcionario { get => Mapper.Map<IFuncionario>(Funcionario); set => throw new NotImplementedException(); }
        IRestaurante IVoto.Restaurante { get => Mapper.Map<IRestaurante>(Restaurante); set => throw new NotImplementedException(); }
    }
}