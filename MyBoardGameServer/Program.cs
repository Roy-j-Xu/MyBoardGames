using MyBoardGameServer;


var builder = WebApplication.CreateBuilder(args);

var initializer = new Initializer(builder);

initializer.RunApplication();
