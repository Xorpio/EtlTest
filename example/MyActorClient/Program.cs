using asp;
using Dapr.Actors;
using Dapr.Actors.Client;
using System;
using System.Threading.Tasks;

namespace MyActorClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await InvokeActorMethodWithRemotingAsync();
            Console.WriteLine("middel");
            await InvokeActorMethodWithoutRemotingAsync();
            Console.WriteLine("done");
        }

        static async Task InvokeActorMethodWithRemotingAsync()
        {
            var actorType = "MyActor";      // Registered Actor Type in Actor Service
            var actorID = new ActorId("1");

            // Create the local proxy by using the same interface that the service implements
            // By using this proxy, you can call strongly typed methods on the interface using Remoting.
            var proxy = ActorProxy.Create<IMyActor>(actorID, actorType);
            var response = await proxy.SetDataAsync(new MyData()
            {
                PropertyA = "ValueA",
                PropertyB = "ValueB",
            });
            Console.WriteLine(response);

            var savedData = await proxy.GetDataAsync();
            Console.WriteLine(savedData);
        }

        static async Task InvokeActorMethodWithoutRemotingAsync()
        {
            var actorType = "MyActor";
            var actorID = new ActorId("1");

            // Create Actor Proxy instance to invoke the methods defined in the interface
            var proxy = ActorProxy.Create(actorID, actorType);
            // Need to specify the method name and response type explicitly
            var response = await proxy.InvokeAsync<string>("SetDataAsync", new MyData()
            {
                PropertyA = "ValueA",
                PropertyB = "ValueB",
            });
            Console.WriteLine(response);

            var savedData = await proxy.InvokeAsync<MyData>("GetDataAsync");
            Console.WriteLine(savedData);
        }
    }
}
