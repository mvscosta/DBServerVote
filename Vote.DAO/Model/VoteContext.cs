using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;

namespace Vote.DAO
{
    public class VoteContext : VoteEF, IVoteContext
    {
        IDbSet<ICategoria> IVoteContext.Categorias { get => Mapper.Map<IDbSet<ICategoria>>(base.Categorias); set => throw new NotImplementedException(); }
        IDbSet<IFuncionario> IVoteContext.Funcionarios { get => Mapper.Map<IDbSet<IFuncionario>>(base.Funcionarios); set => throw new NotImplementedException(); }
        IDbSet<IModalidade> IVoteContext.Modalidades { get => Mapper.Map<IDbSet<IModalidade>>(base.Modalidades); set => throw new NotImplementedException(); }
        IDbSet<IRestaurante> IVoteContext.Restaurantes { get => Mapper.Map<IDbSet<IRestaurante>>(base.Restaurantes); set => throw new NotImplementedException(); }
        IDbSet<IVoto> IVoteContext.Votos { get => Mapper.Map<IDbSet<IVoto>>(base.Votos); set => throw new NotImplementedException(); }
    }
}
