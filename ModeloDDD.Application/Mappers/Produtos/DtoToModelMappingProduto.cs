using AutoMapper;

using ModeloDDD.Application.DTO;
using ModeloDDD.Domain.Entities;

namespace ModeloDDD.Application.Mappers.Produtos
{
    public class DtoToModelMappingProduto : Profile
    {
        public DtoToModelMappingProduto()
        {
            CreateMap<ProdutoDTO, Produto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(x => x.Quantidade))
                .ForMember(dest => dest.IsDisponivel, opt => opt.Ignore())
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(x => x.Valor));
        }
    }
}