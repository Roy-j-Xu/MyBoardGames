using Microsoft.AspNetCore.SignalR;

namespace MyBoardGameServer.Core
{
    public class GameHub(
        ILogger<GameHub> logger
        ) : Hub
    {
        private readonly ILogger<GameHub> _logger = logger;

        public async Task NewMessage(string username, string message)
        {
            _logger.LogInformation($"{username}: {message}.");
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}
