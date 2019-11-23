using System;
using System.Net;
using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace CollectionActors.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeEventController : ControllerBase
    {
        [Topic("EmployeeEvent")]
        [HttpPost]
        public string Index()
        {
            Console.WriteLine("asdlkjsa");
            return "";
            //return guid.ToString();
        }
    }
}
