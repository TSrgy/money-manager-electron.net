using Autofac;
using Avalonia.Controls;
using MoneyManager.Application;
using MoneyManager.Infrastructure;
using Splat;
using System.Reflection;

namespace MoneyManager.DesktopApp
{
    public static class AppBootstrapper
    {
        public static TAppBuilder RegisterAutofacContainer<TAppBuilder>(this TAppBuilder builder)
            where TAppBuilder : AppBuilderBase<TAppBuilder>, new()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            containerBuilder.RegisterModule<ApplicationModule>();
            containerBuilder.RegisterModule<InfrastructureModule>();

            var container = containerBuilder.Build();
            Locator.CurrentMutable.RegisterConstant(container);

            return builder;
        }
    }
}