using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to this project"));
            return Ok($"Job Id: {jobId} Welcome email sent");
        }

        public void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);
        }
    }
}
