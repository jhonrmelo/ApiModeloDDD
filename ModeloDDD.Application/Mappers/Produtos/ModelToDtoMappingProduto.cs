﻿using AutoMapper;

using ModeloDDD.Application.DTO;
using ModeloDDD.Domain.Entities;

namespace ModeloDDD.Application.Mappers.Produtos
{
    public class ModelToDtoMappingProduto : Profile
    {
        public ModelToDtoMappingProduto()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(x => x.Quantidade))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(x => x.Valor));
        }
    }
}