using MySociety.Common.Helper;
using MySociety.Common.Model;
using MySociety.DAL.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MySociety.BAL.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthRepository authRepository;        

        public AuthManager(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public async Task<long> AddUser(User userModel)
        {
            return await authRepository.SaveUserMaster(userModel);
        }

        public async Task<long> DeleteUser(long id)
        {
            return await authRepository.DeleteUser(id);
        }

        public List<User> GetUsers(long id = 0)
        {
            DataSet ds = authRepository.GetUsers(id);
            return HelperMethods.ConvertToList<User>(ds.Tables[0]);
        }

        public async Task<long> UpdateUser(User userModel)
        {
            return await authRepository.UpdateUser(userModel);
        }

        public List<Role> GetRole(int RoleID)
        {
            return HelperMethods.ConvertToList<Role>(authRepository.GetRole(RoleID).Tables[0]);
        }

        public User AuthUser(string username, string password)
        {
            DataSet ds = authRepository.AuthUser(username,password);
            return HelperMethods.ConvertToList<User>(ds.Tables[0]).FirstOrDefault();
        }
    }
}
