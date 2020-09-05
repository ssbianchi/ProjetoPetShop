using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShop.IamMicroserver.Admin.EntityFramework.Shared.DbContexts;
using PetShop.IamMicroserver.STS.Identity.Helpers;

namespace PetShop.IamMicroserver.STS.Identity.Configuration.Test
{
    public class StartupTest : Startup
    {
        public StartupTest(IWebHostEnvironment environment, IConfiguration configuration) : base(environment, configuration)
        {
        }

        public override void RegisterDbContexts(IServiceCollection services)
        {
            services.RegisterDbContextsStaging<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext>();
        }
    }
}





