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
        private readonly UserRepository _userRepository = userRepository;

        private readonly ILogger<UserController> _logger = logger;


        [HttpGet("AddUser")]
        public User AddUser()
        {
            return _userRepository.Add(new User { Username = "Test" });
        }

        [HttpGet()]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

    }
}
