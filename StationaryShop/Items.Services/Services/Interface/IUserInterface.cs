using Items.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Services.Services.Interface
{
    public interface IUserInterface
    {
        Task AddUser(User user);
        User? Login(string username, string password);
    }
}
