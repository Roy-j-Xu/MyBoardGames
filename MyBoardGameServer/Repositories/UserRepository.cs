using MyBoardGameServer.Data;
using MyBoardGameServer.Models;

namespace MyBoardGameServer.Repositories
{
    public class UserRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
