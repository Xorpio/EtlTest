namespace asp
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Dapr.Actors.AspNetCore;

    public class Program
    {
        private const int AppChannelHttpPort = 3000;
        
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseActors(actorRuntime =>
                {
                    // Register MyActor actor type
                    actorRuntime.RegisterActor<MyActor>();
                }
                )
                .UseUrls($"http://localhost:{AppChannelHttpPort}/");
    }
}
