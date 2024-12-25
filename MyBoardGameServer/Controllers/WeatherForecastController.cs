using Microsoft.AspNetCore.Mvc;
using MyBoardGameServer.Models;
using MyBoardGameServer.Repositories;

namespace MyBoardGameServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        UserRepository userRepository
            ) : ControllerBase
    {
        private readonly UserRepository _userRepository = userRepository;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger = logger;

        [HttpGet("AddUser")]
        public User AddUser()
        {
            return _userRepository.Add(new User { UserName = "Test" });
            //return _userRepository.GetAll();
        }

        [HttpGet("Users")]
        public IEnumerable<User>  GetUsers()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
