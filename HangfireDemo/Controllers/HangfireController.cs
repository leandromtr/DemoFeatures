using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangfireController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from hangfire webApi!");
        }

    }
}
