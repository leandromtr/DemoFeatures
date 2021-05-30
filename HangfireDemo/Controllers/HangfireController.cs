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
        // Fire And Forget Job
        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to this project"));
            return Ok($"Job Id: {jobId} Welcome email sent");
        }


        // Delay Job
        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            int timeInSecounds = 10;
            var jobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Welcome to this project"), TimeSpan.FromSeconds(timeInSecounds));
            return Ok($"Job Id: {jobId} Discount email will be send in {timeInSecounds} second(s)");
        }

        public void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);
        }
    }
}
