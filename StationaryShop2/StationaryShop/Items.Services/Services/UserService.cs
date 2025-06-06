using Items.DataAccess.Models;
using Items.DataAccess.Repositories.Interface;
using Items.Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Services.Services
{
    public class UserService : IUserInterface
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // To Add User
        public async Task AddUser(User user)
        {
            await this._userRepository.AddUser(user);
        }

        // Login API
        public User? Login(string email, string password)
        {
            return this._userRepository.Login(email, password);
        }

        public async Task<List<UserVM>> GetAllUsers(FilterVM filterRequest)
        {
            var users = await _userRepository.GetAllUser(filterRequest);

            return users.Select(u => new UserVM()
            {
                Email = u.Email,
                Id = u.Id,
                Name = u.Name,
                Role = u.Role,
                Item = u.Item.Select(u => new Item()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Description = u.Description,
                    Price = u.Price
                }).ToList()
            }).ToList();
        }
    }
}
