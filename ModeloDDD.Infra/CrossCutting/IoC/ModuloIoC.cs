using Autofac;

namespace ModeloDDD.Infra.CrossCutting.IoC
{
    public class ModuloIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Configuration.Load(builder);
        }
    }
}