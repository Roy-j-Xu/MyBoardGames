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

        private readonly ILogger<WeatherForecastController> _logger = logger;


        [HttpGet("AddUser")]
        public User AddUser()
        {
            return _userRepository.Add(new User { Username = "Test" });
            //return _userRepository.GetAll();
        }

        [HttpGet("Users")]
        public IEnumerable<User>  GetUsers()
        {
            return _userRepository.GetAll();
        }

    }
}
