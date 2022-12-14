using MySociety.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MySociety_DataAccessLayer.Interface
{
    public interface IAuthRepository
    {
        DataSet GetUsers(long? id);        
        Task<long> SaveUserMaster(User userModel);
        Task<long> DeleteUser(long id);
        Task<long> UpdateUser(User userModel);
        DataSet GetRole(int RoleID);
        public DataSet AuthUser(string username, string password);
    }
}
