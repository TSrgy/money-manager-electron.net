using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MoneyManager.Application.Common.Behaviours;
using System.Reflection;

namespace MoneyManager.Application
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(Assembly.GetExecutingAssembly(),
                typeof(RequestPerformanceBehaviour<,>), 
                typeof(RequestValidationBehavior<,>));

            builder.RegisterAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
