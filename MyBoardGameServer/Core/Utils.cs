namespace MyBoardGameServer.Core
{
    public class Utils
    {
        public static string GetGameName(Type type)
        {
            var gameName = type.Name;
            if (gameName.EndsWith("Game"))
            {
                gameName = gameName.Substring(0, gameName.Length - 4);
            }
            else if (gameName.EndsWith("Hub"))
            {
                gameName = gameName.Substring(0, gameName.Length - 3);
            }
            return gameName;
        }
    }
}
