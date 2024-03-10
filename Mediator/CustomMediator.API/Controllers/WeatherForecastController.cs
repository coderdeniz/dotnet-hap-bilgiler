using CustomMediator.API.Query;
using CustomMediator.Library.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomMediator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator= mediator;
        }
       
        [HttpGet]
        public Task<UserViewModel> Get()
        {
            return _mediator.Send(new GetUserByIdQuery(1));
        }
    }
}