using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vote.DAO;
using Vote.ViewModels;

namespace Vote.Extensions.Mapper
{
    public class VoteProfile : Profile
    {
        public VoteProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Modalidade, ModalidadeViewModel>().ReverseMap();
            CreateMap<Voto, VotoViewModel>().ReverseMap();
            CreateMap<Restaurante, RestauranteViewModel>().ReverseMap();
        }

    }
}