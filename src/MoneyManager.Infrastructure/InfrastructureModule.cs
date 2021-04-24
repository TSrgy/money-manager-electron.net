using Autofac;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Common.Interfaces;
using MoneyManager.Infrastructure.Persistence;
using MoneyManager.Infrastructure.Services;

namespace MoneyManager.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private DbContextOptions GetDbContextOptions(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //builder.UseSqlite("Filename=test.db");
            builder.UseSqlite(connectionString);

            return builder.Options;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Configuration>()
                .InstancePerLifetimeScope();

            builder.Register(serviceProvider =>
            {
                var configuration = serviceProvider.Resolve<Configuration>();
                var dateTime = serviceProvider.Resolve<IDateTime>();
                return new ApplicationDbContext(GetDbContextOptions(configuration.ConnectionString), dateTime);
            })
                .InstancePerLifetimeScope()
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterType<DateTimeService>()
                .As<IDateTime>()
                .InstancePerDependency();
        }
    }
}
