using CollectionActors.Actors;
using Dapr.Actors.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CollectionActors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebhostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebhostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseActors(actorRuntime =>
                {
                    //Register MyActor actor type
                    actorRuntime.RegisterActor<CollectionActor>();
                })
                .UseUrls($"http://localhost:6020/");
    }
}
