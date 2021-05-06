using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastServices _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get();
            return result;
        }
        [HttpGet("currentDay/{max}")]
        //[Route("currentDay")]
        public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)
        {
            var result = _service.Get();
            return result;
        }

        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401;
            //return StatusCode(401, $"Hello {name}");
            return NotFound($"Hello {name}");
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> GenerateForecasts(
            [FromQuery]int howMany,
            [FromBody]TempRequest request)
        {
            if (howMany < 1 || request.min > request.max )
            {
                return BadRequest();
            }
            var result = _service.Get(howMany, request.min, request.max);
            return Ok(result);
        }

    }
}
