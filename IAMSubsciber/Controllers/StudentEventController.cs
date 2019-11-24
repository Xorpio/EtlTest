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
    public class StudentEventController : ControllerBase
    {
        [Topic("StudentEvent")]
        [HttpPost]
        public async Task Index(SubscribeEvent<StudentEvent> actionEvent)
        {
            Console.WriteLine(actionEvent.data.Guid.ToString());
            var actor = ActorProxy.Create<ICollectionActor>(new ActorId("BronStudents"), "CollectionActor");
            if (actionEvent.data.Action == action.Add)
            {
                Console.WriteLine($"New student added: {actionEvent.data.Guid}");
            }
        }
    }
}
