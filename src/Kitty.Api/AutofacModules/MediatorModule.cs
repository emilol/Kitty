using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Features.Variance;
using Kitty.Core.Domain.Handlers.Games;
using Kitty.Core.Infrastructure.MediatR;
using Kitty.Core.Infrastructure.Pipeline;
using MediatR;

namespace Kitty.Api.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterAssemblyTypes(typeof (IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GetAllGamesHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof (IRequestHandler<,>), "handlers");

            builder.RegisterGeneric(typeof (LoggingPreHandler<,>))
                .As(typeof (IPreRequestHandler<,>));

            builder.RegisterGeneric(typeof (ValidationHandler<,>))
                .As(typeof (IPreRequestHandler<,>));

            builder.RegisterGeneric(typeof (LoggingPostHandler<,>))
                .As(typeof (IPostRequestHandler<,>));

            builder.RegisterGenericDecorator(typeof (MediatorPipeline<,>), typeof (IRequestHandler<,>), "handlers");

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return
                    t =>
                        (IEnumerable<object>)
                            c.Resolve(typeof (IEnumerable<>).MakeGenericType(t));
            });
        }
    }
}