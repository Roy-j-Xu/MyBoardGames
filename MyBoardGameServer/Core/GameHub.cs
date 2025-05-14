using Microsoft.AspNetCore.SignalR;

namespace MyBoardGameServer.Core
{
    public class GameHub : Hub
    {
        private readonly ILogger<GameHub> _logger;
        private readonly string _gameName = "Untitled";

        public GameHub(ILogger<GameHub> logger)
        {
            _logger = logger;
            _gameName = Utils.GetGameName(GetType());
        }

        public async Task AddPlayer(string username)
        {
            _logger.LogInformation($"Player {username} has joined the game.");
            await Clients.All.SendAsync("PlayerJoined", username);
        }

        public async Task SendMessage(string username, string message)
        {
            _logger.LogInformation($"{username}: {message}.");
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

        public async Task StartGame()
        {
            _logger.LogInformation($"Game {_gameName} has started");
            await Clients.All.SendAsync("GameStarted");
        }
    }
}
