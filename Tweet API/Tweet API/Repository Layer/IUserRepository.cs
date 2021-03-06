using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweet_API.DTO;
using Tweet_API.Models;

namespace Tweet_API.Repository_Layer
{
    public interface IUserRepository
    {
        bool Add(Users user);
        bool Update(Users user);
        Users VerifyLogin(Login login);
        bool ValidateEmail(string email);

        bool DeleteUser(int Id);

        bool UpdatePassword(string email,string password);
        bool Logout(int id);

        bool verifyOldPassword(string email, string oldPassword);
    }
}
