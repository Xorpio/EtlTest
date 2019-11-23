using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Bronsysteem;
using CollectionActors.Actors;
using Dapr;
using Dapr.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;

namespace CollectionActors.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeEventController : ControllerBase
    {
        [Topic("EmployeeEvent")]
        [HttpPost]
        public async Task Index(SubscribeEvent<EmployeeEvent> actionEvent)
        {
            Console.WriteLine(actionEvent.data.Guid.ToString());
            var actor = ActorProxy.Create<IEmployeeCollectionActor>(new ActorId("EmployeeCollectionActor"), "EmployeeCollectionActor");
            if (actionEvent.data.Action == action.Add)
            {
                var response = await actor.AddGuid(actionEvent.data.Guid);
            }
        }
    }
}
