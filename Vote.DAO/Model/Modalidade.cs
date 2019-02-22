namespace Vote.DAO
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using Vote.Core.Interfaces.Model;

    public partial class Modalidade : IModalidade
    {
        ICollection<IRestaurante> IModalidade.Restaurantes { get => Mapper.Map<ICollection<IRestaurante>>(Restaurantes); set => throw new NotImplementedException(); }
    }
}