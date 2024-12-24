using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;

namespace MultipleLanguages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureLocalization(builder.Services);
            builder.Services.AddControllers();
            builder.Services.AddLocalization(options => options.ResourcesPath = "Messages");
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // UseRequestLocalization use it before other request configurations 

            app.UseRequestLocalization(); // will use DefaultRequestCulture for blank or incorrect Accept-Language in header
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void ConfigureLocalization(IServiceCollection services)
        {
            services.AddLocalization(options =>
            {
                // sets the path to the folder where the resource file reside, not necessary when Resources.Designer.cs file is used 
                options.ResourcesPath = "";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCulture =
                [
                    new CultureInfo("en-US"),
                    new CultureInfo("hi-IN"),
                ];
                options.DefaultRequestCulture = new RequestCulture("hi-IN");
                options.SupportedCultures = supportedCulture;
                options.SupportedUICultures = supportedCulture;
            });
        }
    }
}
