using Microsoft.AspNet.Hosting;

namespace Kitty.Api
{
    public class Program
    {
        // Entry point for the application.
        public static void Main(string[] args)
        {
            var app = new WebApplicationBuilder()
                .UseConfiguration(WebApplicationConfiguration.GetDefault(args))
                .UseStartup<Startup>()
                .Build();

            app.Run();
        }
    }
}