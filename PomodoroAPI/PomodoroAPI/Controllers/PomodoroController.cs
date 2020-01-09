using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PomodoroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PomodoroController : ControllerBase
    {
        private readonly ILogger<PomodoroController> _logger;

        public PomodoroController(ILogger<PomodoroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Pomodoro> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Pomodoro
            {
                Date = DateTime.Now.AddDays(index),
                Tag = "Bla",
                Timer = 800
            }).ToArray();
        }

        [Route("/pomodoro/{t}")]
        [HttpGet]
        public IEnumerable<Pomodoro> Get(string t)
        {
            return Enumerable.Range(1, 5).Select(index => new Pomodoro
            {
                Date = DateTime.Now.AddDays(index),
                Tag = t,
                Timer = 800
            }).ToArray();
        }
    }


}

