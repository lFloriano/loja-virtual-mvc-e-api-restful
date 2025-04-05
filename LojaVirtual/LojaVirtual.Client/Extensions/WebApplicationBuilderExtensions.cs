using LojaVirtual.Client.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Client.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            var lojaVirtualConnection = builder.Configuration.GetConnectionString("LojaVirtualConnection") ?? throw new InvalidOperationException("Connection string 'LojaVirtualConnection' not found.");
            var identityConnection = builder.Configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Connection string 'IdentityConnection' not found.");

            builder.Services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(lojaVirtualConnection));
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(identityConnection));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }
    }
}
