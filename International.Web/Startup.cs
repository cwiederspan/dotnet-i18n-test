using System;
using System.Collections.Generic;
using System.Globalization;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace International.Web {

    public class Startup {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {

            //services.AddLocalization(options => {
            //    options.ResourcesPath = "Localization";
            //});

            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(options => {

                var supportedCultures = new List<CultureInfo> {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-ES")
                };

                options.DefaultRequestCulture = new RequestCulture(
                    culture: "en-US", 
                    uiCulture: "en-US"
                );

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            // Setup to handle the culture handler, via Accept-Language header
            var localizationOptions = app
                .ApplicationServices
                .GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOptions.Value);

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
