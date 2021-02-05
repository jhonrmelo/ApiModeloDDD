using AutoMapper;

using ModeloDDD.Application.Mappers.Clientes;
using ModeloDDD.Application.Mappers.Produtos;

namespace ModeloDDD.Application.Factory
{
    public static class AutoMapperFactory
    {
        public static IMapper CreaterAutoMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DtoToModelMappingCliente());
                mc.AddProfile(new ModelToDtoMappingCliente());
                mc.AddProfile(new DtoToModelMappingProduto());
                mc.AddProfile(new ModelToDtoMappingProduto());
            });
            return mappingConfig.CreateMapper();
        }
    }
}