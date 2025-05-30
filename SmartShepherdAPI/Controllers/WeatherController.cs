using Microsoft.AspNetCore.Mvc;
using SmartShepherdAPI.Models;

namespace SmartShepherdAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetWeather([FromBody] WeatherRequest request)
        {
            return Ok(new { location = request.Location, forecast = "Sunny", temperature = "25°C" });
        }
    }
}
