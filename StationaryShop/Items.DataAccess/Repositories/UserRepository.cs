
using Items.DataAccess;
using Items.DataAccess.Models;
using Items.DataAccess.Repositories.Interface;

namespace Items.DataAccess.Repositories
{
    public class UserRepository(ItemsDbContext itemsDbContext) : IUserRepository
    {
        private readonly ItemsDbContext _dbContext = itemsDbContext;

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public User? Login(string username, string password)
        {
            var user = _dbContext.Users.Where(x => x.Email == username && x.Password == password).FirstOrDefault();
            return user;
        }
    }
}
