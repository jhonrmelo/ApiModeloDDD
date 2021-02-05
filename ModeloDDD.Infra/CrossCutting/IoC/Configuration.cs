using Autofac;

using ModeloDDD.Application;
using ModeloDDD.Application.Interfaces;

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
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();

            #endregion DI
        }
    }
}