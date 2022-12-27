using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MySociety.DAL.Helper.Interface
{
    public interface ISQLHelper
    {
        DataSet GetData(string sp, SqlParameter[] prm = null);
        Task<int> ExecuteNonQuery(string sp, SqlParameter[] prm = null);
        Task<string> ExecuteScalar(string sp, SqlParameter[] prm = null);
    }
}
