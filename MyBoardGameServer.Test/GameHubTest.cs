using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Moq;
using MyBoardGameServer.Core;
using System.Threading.Tasks;

namespace MyBoardGameServer.Test
{
    [TestClass]
    public class GameHubTest
    {
        private static Mock<IHubCallerClients> mockClients;
        private static Mock<IClientProxy> mockClientProxy;
        private static Mock<ILogger<GameHub>> mockLogger;
        private static GameHub gameHub;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            mockClients = new Mock<IHubCallerClients>();
            mockClientProxy = new Mock<IClientProxy>();
            mockLogger = new Mock<ILogger<GameHub>>();

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            gameHub = new GameHub(mockLogger.Object)
            {
                Clients = mockClients.Object,
            };
        }

        [TestMethod]
        public void Test()
        {
            
        }

    }
}