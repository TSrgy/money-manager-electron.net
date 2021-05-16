using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using FluentValidation;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MoneyManager.Application.Common.Behaviours;

namespace MoneyManager.Application
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.GetInterfaces().Any(x => x == typeof(IValidator)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<AutofacValidatorFactory>()
                .As<IValidatorFactory>()
                .SingleInstance();

            builder.RegisterMediatR(
                Assembly.GetExecutingAssembly(),
                typeof(RequestPerformanceBehaviour<,>),
                typeof(RequestValidationBehavior<,>));

            builder.RegisterAutoMapper(Assembly.GetExecutingAssembly());

        }
    }
}
