using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace BronImporters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        [HttpGet]
        public HttpStatusCode Import()
        {
            return HttpStatusCode.OK;
        }
    }
}
