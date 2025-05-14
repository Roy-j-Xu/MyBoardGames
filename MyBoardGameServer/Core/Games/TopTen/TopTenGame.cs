using MyBoardGameServer.Core.Models;

namespace MyBoardGameServer.Core.Games.TopTen
{
    public class TopTenGame : Game
    {
        public TopTenPlayer? Lead { get; set; }

        public void AddTopTenPlayer(string Name)
        {
            AddPlayer(new TopTenPlayer { 
                Name = Name,
                Answer = null,
            });
        }
    }
}
