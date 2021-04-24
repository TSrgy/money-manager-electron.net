using System;
using System.IO;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using ElectronApp;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Infrastructure.Persistence;
using Moq;

namespace Application.IntegrationTests
{
    public class DatabaseFixture : IDisposable
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly SqliteConnection _mainDbConnection;
        private readonly SqliteConnection _cleanDbConnection;

        public DatabaseFixture()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", true, true)
              .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(_configuration);

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "ElectronApp"));

            services.AddLogging();

            startup.ConfigureServices(services);

            IServiceProvider serviceProvider = CreateAutofacServiceProvider(startup, services);

            _scopeFactory = serviceProvider.GetService<IServiceScopeFactory>();

            _cleanDbConnection = new SqliteConnection("Data Source=:memory:");
            _cleanDbConnection.Open();
            _mainDbConnection = OpenConnectionAndEnsureDatabase();
            SaveDB(_mainDbConnection);
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<ISender>();

            return await mediator.Send(request);
        }

        public void ResetState()
        {
            using var scope = _scopeFactory.CreateScope();
            RestoreDB(_mainDbConnection);
        }

        public async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public async Task<int> CountAsync<TEntity>()
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.Set<TEntity>().CountAsync();
        }

        public void Dispose()
        {
            _cleanDbConnection.Dispose();
            _mainDbConnection.Dispose();
        }

        private static IServiceProvider CreateAutofacServiceProvider(Startup startup, ServiceCollection services)
        {
            var autofactSPFactory = new AutofacServiceProviderFactory();

            var builder = autofactSPFactory.CreateBuilder(services);
            startup.ConfigureContainer(builder);

            var serviceProvider = autofactSPFactory.CreateServiceProvider(builder);
            return serviceProvider;
        }

        private void SaveDB(SqliteConnection srcConnection)
        {
            srcConnection.BackupDatabase(_cleanDbConnection);
        }

        private void RestoreDB(SqliteConnection destConnection)
        {
            _cleanDbConnection.BackupDatabase(destConnection);
        }

        private SqliteConnection OpenConnectionAndEnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            var connection = new SqliteConnection(context.Database.GetConnectionString());
            connection.Open();

            context.Database.Migrate();

            return connection;
        }
    }
}
