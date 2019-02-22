namespace Vote.DAO
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using Vote.Core.Interfaces.Model;

    public partial class Restaurante : IRestaurante
    {
        ICategoria IRestaurante.Categoria { get => Mapper.Map<ICategoria>(Categoria); set => throw new NotImplementedException(); }
        IModalidade IRestaurante.Modalidade { get => Mapper.Map<IModalidade>(Modalidade); set => throw new NotImplementedException(); }
    }
}