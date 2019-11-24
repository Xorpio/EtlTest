using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Bronsysteem;
using Bronsysteem.Events;
using CollectionActors.Actors;
using Dapr;
using Dapr.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;

namespace CollectionActors.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContractEventController : ControllerBase
    {
        [Topic("ContractEvent")]
        [HttpPost]
        public async Task Index(SubscribeEvent<ContractEvent> actionEvent)
        {
            Console.WriteLine(actionEvent.data.Guid.ToString());
            var actor = ActorProxy.Create<ICollectionActor>(new ActorId("BronContracts"), "CollectionActor");
            if (actionEvent.data.Action == action.Add)
            {
                Console.WriteLine($"New contract added: {actionEvent.data.Guid}");
            }
        }
    }
}
