using Microsoft.EntityFrameworkCore;
using MyBoardGameServer.Data;
using MyBoardGameServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Get flags
bool useDatabase = builder.Configuration["UseDatabase"] == "true";

// Add services to the container.
builder.Services.AddScoped<UserRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


if (useDatabase || builder.Environment.IsProduction())
{
    string? connectionString = builder.Configuration.GetConnectionString("Postgres");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString)
    );
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb")  // In-memory database
    );
}


// Build app
var app = builder.Build();
var logger = app.Services.GetService<ILogger<Program>>();

// Some random logging
logger?.LogInformation("Hello World");
logger?.LogInformation(useDatabase.ToString());



// Initialize data
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    context.Users.Add(new MyBoardGameServer.Models.User { UserName = "Test" });
//    context.SaveChanges();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
