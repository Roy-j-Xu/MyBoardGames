using Microsoft.AspNetCore.Mvc;
using MyBoardGameServer.Models;
using MyBoardGameServer.Repositories;

namespace MyBoardGameServer.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController(
        ILogger<UserController> logger,
        UserRepository userRepository
            ) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly UserRepository _userRepository = userRepository;

        [HttpGet("AddUser")]
        public User AddUser()
        {
            _logger.LogInformation("Added new user \"Test\".");
            return _userRepository.Add(new User { Username = "Test" });
        }

        [HttpGet()]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

    }
}
