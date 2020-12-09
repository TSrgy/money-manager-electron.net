using Autofac;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Common.Interfaces;
using MoneyManager.Infrastructure.Persistence;
using MoneyManager.Infrastructure.Services;

namespace MoneyManager.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private DbContextOptions GetDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlite();

            return builder.Options;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("options", GetDbContextOptions())
                .InstancePerLifetimeScope()
             .AsImplementedInterfaces();

            //if (environment.IsEnvironment("Test"))
            //{
            //    services.AddIdentityServer()
            //        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
            //        {
            //            options.Clients.Add(new Client
            //            {
            //                ClientId = "ca_sln.IntegrationTests",
            //                AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
            //                ClientSecrets = { new Secret("secret".Sha256()) },
            //                AllowedScopes = { "ca_sln.WebUIAPI", "openid", "profile" }
            //            });
            //        }).AddTestUsers(new List<TestUser>
            //        {
            //            new TestUser
            //            {
            //                SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
            //                Username = "jason@clean-architecture",
            //                Password = "ca_sln!",
            //                Claims = new List<Claim>
            //                {
            //                    new Claim(JwtClaimTypes.Email, "jason@clean-architecture")
            //                }
            //            }
            //        });
            //}
            //else
            //{
            builder.RegisterType<DateTimeService>()
                .As<IDateTime>()
                .InstancePerDependency();
            //}

         
        }
    }
}
