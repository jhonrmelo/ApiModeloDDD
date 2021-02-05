using AutoMapper;

using ModeloDDD.Application.DTO;
using ModeloDDD.Domain.Entities;

namespace ModeloDDD.Application.Mappers.Clientes
{
    public class DtoToModelMappingCliente : Profile
    {
        public DtoToModelMappingCliente()
        {
            CreateMap<ClienteDTO, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.SobreNome))
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.DataCadastro, opt => opt.Ignore());
        }
    }
}