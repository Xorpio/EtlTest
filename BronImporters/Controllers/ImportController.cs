using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Bronsysteem;
using Bronsysteem.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;

namespace BronImporters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        [HttpGet]
        public async Task<HttpStatusCode> Import()
        {
            var jsonString = System.IO.File.ReadAllText("../GenerateData/Employees.json");
            var employees = JsonSerializer.Deserialize<IList<Employee>>(jsonString);

            var tasks = employees.Select(async emp =>
            {
                // some pre stuff
                var actor = ActorProxy.Create<IEmployeeActor>(new Dapr.Actors.ActorId(emp.Guid.ToString()), "EmployeeActor");
                var response = await actor.SetEmployeeAsync(emp);
            });
            await Task.WhenAll(tasks);

            return HttpStatusCode.OK;
        }
    }
}
