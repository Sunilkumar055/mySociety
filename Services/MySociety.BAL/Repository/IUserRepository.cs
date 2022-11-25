using MySociety.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySociety.BAL.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUserById(long? id);
        Task<long> AddUser(UserModel userModel);
        Task<long> DeleteUser(long? id);
        Task UpdateUser(UserModel userModel);
    }
}
