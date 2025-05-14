using Microsoft.EntityFrameworkCore;
using MyBoardGameServer.Core.Models;

namespace MyBoardGameServer.Data
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}