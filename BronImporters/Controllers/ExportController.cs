using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace BronImporters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        [HttpGet]
        public HttpStatusCode Export()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
