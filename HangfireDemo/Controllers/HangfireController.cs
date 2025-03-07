﻿using Hangfire;
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


        // Recurring Job
        [HttpPost]
        [Route("[action]")]
        public IActionResult DataBaseUpdate()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Database Update"), Cron.Minutely);
            return Ok($"Database check job initiated!");
        }


        // Continous Job
        [HttpPost]
        [Route("[action]")]
        public IActionResult Confirm()
        {
            int timeInSecounds = 10;
            var parentJobId = BackgroundJob.Schedule(() => Console.WriteLine("You asked to be unsubscribed"), TimeSpan.FromSeconds(timeInSecounds));
            BackgroundJob.ContinueJobWith(parentJobId,() => Console.WriteLine("You were unsubscribed!"));
            return Ok("Confirmation Job created");
        }


        public void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);
        }
    }
}
