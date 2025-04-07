using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace LojaVirtual.Client.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapStaticAssets();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Produtos}/{action=Index}/{id?}")
                .WithStaticAssets();

            // Define a cultura pt-BR
            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            app.UseRequestLocalization(localizationOptions);

            //app.MapRazorPages()
            //   .WithStaticAssets();
        }
    }
}
