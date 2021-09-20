using Autofac;

namespace WebApplication1
{
    public class DependencyRegistrarModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Test>().As<ITest>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
