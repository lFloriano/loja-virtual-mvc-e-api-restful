using LojaVirtual.Client.Data;
using LojaVirtual.Core.Data;
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

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<LojaVirtualContext>(options => options.UseSqlite("Data Source=app.db"));
                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(""));
                builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            }
            else
            {
                builder.Services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(lojaVirtualConnection));
                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(identityConnection));
            }

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }
    }
}
