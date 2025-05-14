using System.Xml.Linq;

namespace MyBoardGameServer.Core.Models
{
    public class Game
    {
        public int CurrentRound { get; set; } = 0;
        public List<Player> Players { get; set; } = [];

        public int NextRound()
        {
            CurrentRound++;
            return CurrentRound;
        }

        public void AddPlayer(Player player)
        {
            if (Players.Any(p => p.Name == player.Name))
            {
                throw new Exception($"Player {player.Name} already exists.");
            }
            Players.Add(player);
        }
    }
}
