using Microsoft.Data.SqlClient;
using MySociety.Common.Model;
using MySociety.Common.Helper;
using MySociety_DataAccessLayer.Helper.Interface;
using MySociety_DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySociety.Common.Configurations;

namespace MySociety_DataAccessLayer
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ISQLHelper sQLHelper;
        public AuthRepository(ISQLHelper sQLHelper)
        {
            this.sQLHelper = sQLHelper;
        }

        public DataSet AuthUser(string username, string password)
        {
            SqlParameter[] sqlParameters = {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
            };
            return sQLHelper.GetData(StoreProcedures.spAuthUser, sqlParameters);
        }

        public async Task<long> DeleteUser(long id)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", id)
            };
            return await sQLHelper.ExecuteNonQuery(StoreProcedures.spDeleteUser, parameters);
        }

        public DataSet GetRole(int RoleID)
        {
            SqlParameter[] sqlParameters = {
            new SqlParameter("@RoleID", RoleID)
            };
            return sQLHelper.GetData(StoreProcedures.spGetRole, sqlParameters);
        }

        public DataSet GetUsers(long? id)
        {
            SqlParameter[] sqlParameters = {
            new SqlParameter("@UserId", id)
            };
            return sQLHelper.GetData(StoreProcedures.spGetUserMaster, sqlParameters);
        }

        public async Task<long> SaveUserMaster(User user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@ConactNumber", user.ConactNumber),
                new SqlParameter("@AlternateContactNumber", user.AlternateContactNumber),
                new SqlParameter("@WhatsAppNumber", user.WhatsAppNumber),
                new SqlParameter("@EmailID", user.EmailID),
                new SqlParameter("@Address", user.Address),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@FlatNumberID", user.FlatNumberID),
                new SqlParameter("@IsActive", user.IsActive),
                new SqlParameter("@CreatedDate", user.CreatedDate)
            };
            return await sQLHelper.ExecuteNonQuery(StoreProcedures.spInsertUserMaster, parameters);
        }

        public async Task<long> UpdateUser(User user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@ConactNumber", user.ConactNumber),
                new SqlParameter("@AlternateContactNumber", user.AlternateContactNumber),
                new SqlParameter("@WhatsAppNumber", user.WhatsAppNumber),
                new SqlParameter("@EmailID", user.EmailID),
                new SqlParameter("@Address", user.Address),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@FlatNumberID", user.FlatNumberID),
                new SqlParameter("@IsActive", user.IsActive)
            };
            return await sQLHelper.ExecuteNonQuery(StoreProcedures.spUpdateUser, parameters);
        }
    }
}
