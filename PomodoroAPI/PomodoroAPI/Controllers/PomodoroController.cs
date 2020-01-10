using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
/*using System.Net.Http;*/
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PomodoroAPI.DAL;

namespace PomodoroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PomodoroController : ControllerBase
    {
        private readonly ILogger<PomodoroController> _logger;

        GetPomodoro gt = new GetPomodoro();
        PostPomodoro pt = new PostPomodoro();

        public PomodoroController(ILogger<PomodoroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Pomodoro> Get()
        {
            return gt.selectPomodoro().ToList();
        }

        [Route("/pomodoro/{t}")]
        [HttpGet]
        public IEnumerable<Pomodoro> Get(string t)
        {
            return gt.selectPomodoroByTag(t).ToList();
        }

        [Route("/pomodoro")]
        [HttpPost]
        public void Post(string t, int ti)
        {
            pt.insertPomodoro(t, ti);
        }
    }


}

