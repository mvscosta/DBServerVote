namespace Vote.DAO
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using Vote.Core.Interfaces.Model;

    public partial class Funcionario : IFuncionario
    {
        ICollection<IVoto> IFuncionario.Votos { get => Mapper.Map<ICollection<IVoto>>(Votos); set => throw new NotImplementedException(); }
    }
}