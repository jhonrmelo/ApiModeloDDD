using Autofac;

using AutoMapper;

using ModeloDDD.Application;
using ModeloDDD.Application.Interfaces;
using ModeloDDD.Application.Mappers.Clientes;
using ModeloDDD.Application.Mappers.Produtos;
using ModeloDDD.Domain.Core.Interfaces.Repositories;
using ModeloDDD.Domain.Core.Interfaces.Services;
using ModeloDDD.Domain.Services;
using ModeloDDD.Infra.Data.Repository;

namespace ModeloDDD.Infra.CrossCutting.IoC
{
    public class Configuration
    {
        public static void Load(ContainerBuilder builder)
        {
            #region DI

            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingCliente());
                cfg.AddProfile(new ModelToDtoMappingCliente());
                cfg.AddProfile(new DtoToModelMappingProduto());
                cfg.AddProfile(new ModelToDtoMappingProduto());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            #endregion DI
        }
    }
}