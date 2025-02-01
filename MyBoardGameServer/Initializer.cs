﻿using Microsoft.EntityFrameworkCore;
using MyBoardGameServer.Data;
using MyBoardGameServer.Repositories;

namespace MyBoardGameServer
{
    public class Initializer(WebApplicationBuilder builder)
    {
        private readonly WebApplicationBuilder _builder = builder;
        private readonly Dictionary<string, bool> _flags = new()
        {
            { "UseDatabase", true },
        };

        public void RunApplication()
        {
            GetFlags();

            var app = BuildApplication();

            InitializeData(app);

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
        }

        public WebApplication BuildApplication()
        {
            var services = _builder.Services;
            // Add services to the container.
            services.AddScoped<UserRepository>();
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Database flag
            //if (_flags["UseDatabase"])
            {
                string? connectionString = _builder.Configuration.GetConnectionString("Postgres");
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(connectionString)
                );
            }
            //else
            //{
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseInMemoryDatabase("InMemoryDb")  // In-memory database
            //    );
            //}

            return _builder.Build();
        }

        private void InitializeData(WebApplication? app)
        {
            if (!_flags["UseDatabase"] && app != null)
            {
                // Initialize data
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    context.Users.Add(new Models.User { Username = "In-Memory User" });
                    context.SaveChanges();
                }
            }
        }

        private void GetFlags()
        {
            var config = _builder.Configuration;
            foreach (string flag in _flags.Keys)
            {
                _flags[flag] = config[flag] == "true";
            }
        }

    }
}
