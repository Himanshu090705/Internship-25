
using Items.DataAccess.Models;

namespace Items.DataAccess.Repositories.Interface
{
    public interface IUserRepository
    {
        Task AddUser(User user);

        User? Login(string email, string password);
    }
}
