using MySociety.Common.Helper;
using MySociety.DAL.Helper.Interface;
using MySociety.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MySociety.DAL
{
    class RoleRepository : IRoleRepository
    {
        private readonly ISQLHelper sQLHelper;

        public RoleRepository(ISQLHelper sQLHelper)
        {
            this.sQLHelper = sQLHelper;
        }

        public DataSet GetRole(int RoleID = 0)
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@RoleID",RoleID)
            };
            return sQLHelper.GetData(StoreProcedures.spGetRole, sqlParameters);
        }
    }
}
