using MySociety.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySociety.BAL.Repository
{
    public interface IAuthManager
    {
        List<User> GetUsers(long id = 0);
        Task<long> AddUser(User userModel);
        Task<long> DeleteUser(long id);
        Task<long> UpdateUser(User userModel);
        List<Role> GetRole(int id = 0);
        public User AuthUser(string username, string password);
    }
}
