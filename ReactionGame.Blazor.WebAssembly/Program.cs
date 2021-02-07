using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using ReactionGame.Blazor.Core.Services;

using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace ReactionGame.Blazor.WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<Core.App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient<IHighscoreDataService, HighscoreDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/Highscores");
            });

            await builder.Build().RunAsync();
        }
    }
}
