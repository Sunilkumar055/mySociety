using Microsoft.Data.SqlClient;
using MySociety.Common.Helper;
using MySociety_DataAccessLayer.Helper.Interface;
using MySociety_DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MySociety_DataAccessLayer
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
