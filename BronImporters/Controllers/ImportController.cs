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
            var employees = ImportEmployees();
            var students = ImportStudents();
            var contracts = ImportContracts();

            await Task.WhenAll(employees, students, contracts);

            return HttpStatusCode.OK;
        }

        private async Task ImportEmployees()
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
        }

        private async Task ImportStudents()
        {
            var jsonString = System.IO.File.ReadAllText("../GenerateData/students.json");
            var students = JsonSerializer.Deserialize<IList<StudentImport>>(jsonString);

            var tasks = students.Select(async stu =>
            {
                // some pre stuff
                var actor = ActorProxy.Create<IStudentActor>(new Dapr.Actors.ActorId(stu.Guid.ToString()), "StudentActor");

                var student = Student.FromStudentImport(stu);

                var response = await actor.SetStudentAsync(student);
            });
            await Task.WhenAll(tasks);
        }


        private async Task ImportContracts()
        {
            var jsonString = System.IO.File.ReadAllText("../GenerateData/contracts.json");
            var contracts = JsonSerializer.Deserialize<IList<Contract>>(jsonString);

            var tasks = contracts.Select(async contract =>
            {
                // some pre stuff
                var actor = ActorProxy.Create<IContractActor>(new Dapr.Actors.ActorId(contract.Guid.ToString()), "ContractActor");
                var response = await actor.SetContractAsync(contract);
            });
            await Task.WhenAll(tasks);
        }
    }
}
