using Microsoft.EntityFrameworkCore;
using MySociety.DataAccessLayer.Model;
using MySociety_DataAccessLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySociety.BAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext applicationDBContext;

        public UserRepository(ApplicationDBContext _applicationDBContext)
        {
            applicationDBContext = _applicationDBContext;
        }

        public async Task<long> AddUser(UserModel userModel)
        {
            if (applicationDBContext != null)
            {
                await applicationDBContext.users.AddAsync(userModel);
                await applicationDBContext.SaveChangesAsync();
                return userModel.userId;
            }
            else
                return 0;
        }

        public async Task<long> DeleteUser(long? id)
        {
            if (applicationDBContext != null)
            {
                applicationDBContext.users.Remove(await applicationDBContext.users.FirstOrDefaultAsync(x => x.userId == id));
                return await applicationDBContext.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<UserModel> GetUserById(long? id)
        {
            if (applicationDBContext != null)
            {
                return await applicationDBContext.users.FirstOrDefaultAsync(x => x.userId == id);
            }
            else
                return null;

        }
        public async Task<List<UserModel>> GetUsers()
        {
            if (applicationDBContext != null)
                return await applicationDBContext.users.ToListAsync();
            else
                return null;
        }

        public async Task UpdateUser(UserModel userModel)
        {
            if (applicationDBContext != null)
            {
                applicationDBContext.users.Update(userModel);
                await applicationDBContext.SaveChangesAsync();
            }
        }
    }
}
