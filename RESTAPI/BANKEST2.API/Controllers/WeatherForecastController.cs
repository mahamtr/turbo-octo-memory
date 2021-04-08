using Microsoft.AspNetCore.Mvc;

namespace BANKEST2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        [HttpGet]
        public int Get()
        {
            return 0;
        }
    }
}
