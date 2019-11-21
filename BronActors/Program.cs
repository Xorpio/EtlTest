using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BronActors.Actors;
using Dapr.Actors.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BronActors
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
                    actorRuntime.RegisterActor<EmployeeActor>();
                })
                .UseUrls($"http://localhost:6000/");
    }
}
