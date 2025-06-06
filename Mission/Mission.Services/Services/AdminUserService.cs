using Mission.Entities;
using Mission.Entities.Dto;
using Mission.Entities.Models;
using Mission.Repositories.Interface;
using Mission.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Services
{
    public class AdminUserService(IAdminUserRepository _adminUserRepository): IAdminUserService
    {
        public List<UserDetails> UserDetailsList()
        {
            return _adminUserRepository.UserDetailsList();
        }
        public string UserDelete(int id)
        {
            return _adminUserRepository.DeleteUser(id);
        }

        public User UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = _adminUserRepository.GetUser(updateUserDto.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.PhoneNumber = updateUserDto.PhoneNumber;
            user.EmailAddress = updateUserDto.EmailAddress;
            user.UserImage = updateUserDto.UserImage;
            return _adminUserRepository.UpdateUser(user);
        }
    }
}
