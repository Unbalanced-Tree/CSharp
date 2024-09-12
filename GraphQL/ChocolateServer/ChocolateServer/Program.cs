using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ChocolateServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<DbHelpers>();
            builder.Services.AddGraphQLServer()
            .AddQueryType<Query>();

            var app = builder.Build();
            app.MapGraphQL();
            app.Run();
        }
    }
}
