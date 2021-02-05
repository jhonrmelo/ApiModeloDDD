using AutoMapper;

using ModeloDDD.Application.DTO;
using ModeloDDD.Domain.Entities;

namespace ModeloDDD.Application.Mappers.Clientes
{
    public class ModelToDtoMappingCliente : Profile
    {
        public ModelToDtoMappingCliente()
        {
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.SobreNome, opt => opt.MapFrom(x => x.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email));
        }
    }
}