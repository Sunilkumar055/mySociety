using MySociety.Common.Configurations;
using MySociety.DAL.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MySociety.DAL.Helper
{
    public class SQLHelper : ISQLHelper
    {

        private readonly ConfigurationManager configurationManager;

        public SQLHelper(ConfigurationManager configurationManager)
        {
            this.configurationManager = configurationManager;
        }

        public async Task<int> ExecuteNonQuery(string sp, SqlParameter[] prm = null)
        {
            SqlConnection connection = new SqlConnection(configurationManager.ConnectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                if (connection != null && !string.IsNullOrEmpty(sp))
                {
                    command = new SqlCommand(sp, connection) { CommandType = CommandType.StoredProcedure, CommandTimeout = connection.ConnectionTimeout };

                    connection.Open();
                    if (prm != null && prm.Length > 0)
                    {
                        command.Parameters.AddRange(prm);
                    }
                    return await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }
            return 0;
        }

        public async Task<string> ExecuteScalar(string sp, SqlParameter[] prm = null)
        {
            SqlConnection connection = new SqlConnection(configurationManager.ConnectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                if (connection != null && !string.IsNullOrEmpty(sp))
                {
                    command = new SqlCommand(sp, connection) { CommandType = CommandType.StoredProcedure, CommandTimeout = connection.ConnectionTimeout };

                    connection.Open();
                    if (prm != null && prm.Length > 0)
                    {
                        command.Parameters.AddRange(prm);
                    }
                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToString(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }
            return string.Empty;
        }

        public DataSet GetData(string sp, SqlParameter[] prm = null)
        {
            SqlConnection connection = new SqlConnection(configurationManager.ConnectionString);
            try
            {
                if (connection != null && !string.IsNullOrEmpty(sp))
                {
                    SqlCommand command = new SqlCommand(sp, connection) { CommandType = CommandType.StoredProcedure, CommandTimeout = connection.ConnectionTimeout };

                    connection.Open();
                    if (prm != null && prm.Length > 0)
                    {
                        command.Parameters.AddRange(prm);
                    }
                    DataSet ds = new DataSet();
                    new SqlDataAdapter(command).Fill(ds);
                    command.Parameters.Clear();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
    }
}
