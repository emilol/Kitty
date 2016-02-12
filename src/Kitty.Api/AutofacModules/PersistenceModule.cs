using Autofac;
using Kitty.Core.Persistence;

namespace Kitty.Api.AutofacModules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KittyContext>()
                .As<IKittyContext>()
                .InstancePerLifetimeScope();
        }
    }
}