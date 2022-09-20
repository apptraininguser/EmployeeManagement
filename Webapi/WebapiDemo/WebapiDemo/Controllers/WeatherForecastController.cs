using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebapiDemo.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public string Get()
        {
            return "helo";
        }

        [HttpGet]
        [Route("getName")]
        public string GetName()
        {
            return "my name is sarath";
        }

        /// <summary>
        /// Eg: Query string url
        /// Url: domain/api/weather/print?message={{value}}
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("print")]
        public string PrintMessage(string message)
        {
            return message;
        }

        /// <summary>
        /// In route format
        /// Url: host:port/api/weather/display/{{value}}
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("display/{message}")]
        public string DisplayMessage([FromRoute]string message)
        {
            return message;
        }
    }
}
