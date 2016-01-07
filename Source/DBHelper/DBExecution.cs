using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;


namespace DBHelper
{
    public class DBExecution
    {
        private NpgsqlConnection connection;
        private NpgsqlDataAdapter da;
        private NpgsqlCommand cmd;
        private CastObjectHelper castObjectHelper;
        public DBExecution()
        {
            try
            {
                castObjectHelper = new CastObjectHelper();
                string cnnString = ConfigurationSettings.AppSettings.Get("DBConnectionString");
                if (connection == null)
                {
                    connection = new NpgsqlConnection(cnnString);
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                da = new NpgsqlDataAdapter(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> ExecuteDataAdapter(string storeName, NpgsqlParameter[] sqlParams)
        {
            List<string> res = null;
            try
            {
                using (NpgsqlTransaction t = connection.BeginTransaction())
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataSet result = new DataSet();
                    cmd.CommandText = DBConstant.BuildStoreName(storeName);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    if (sqlParams != null && sqlParams.Length > 0)
                        cmd.Parameters.AddRange(sqlParams);
                    da.Fill(result);
                    t.Commit();
                    cmd.Connection.Close();
                    if (result.Tables != null && result.Tables[0] != null && result.Tables[0].Rows != null && result.Tables[0].Rows.Count > 0)
                    {
                        res = new List<string>();
                        foreach (DataRow row in result.Tables[0].Rows)
                        {
                            res.Add(row[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }
        public List<T> ExecuteDataAdapter<T>(string storeName, NpgsqlParameter[] sqlParams) where T : new()
        {
            try
            {
                using (NpgsqlTransaction t = connection.BeginTransaction())
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataSet result = new DataSet();
                    cmd.CommandText = DBConstant.BuildStoreName(storeName);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    if (sqlParams != null && sqlParams.Length > 0)
                        cmd.Parameters.AddRange(sqlParams);
                    da.Fill(result);
                    t.Commit();
                    cmd.Connection.Close();
                    if (result.Tables != null && result.Tables[0] != null && result.Tables[0].Rows != null && result.Tables[0].Rows.Count > 0)
                        return castObjectHelper.ConvertTo<T>(result.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return null;
        }
        public bool ExcuteNoneQuery(string storeName, NpgsqlParameter[] sqlParams)
        {
            bool result = false;
            try
            {
                using (NpgsqlTransaction t = connection.BeginTransaction())
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    cmd.CommandText = DBConstant.BuildStoreName(storeName);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    if (sqlParams != null && sqlParams.Length > 0)
                        cmd.Parameters.AddRange(sqlParams);
                    int i = cmd.ExecuteNonQuery();
                    result = i > 0;
                    t.Commit();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return result;
        }

        public int ExecuteScalar(string storeName, NpgsqlParameter[] sqlParams)
        {
            int result = 0;
            try
            {
                using (NpgsqlTransaction t = connection.BeginTransaction())
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    cmd.CommandText = DBConstant.BuildStoreName(storeName);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    if (sqlParams != null && sqlParams.Length > 0)
                        cmd.Parameters.AddRange(sqlParams);
                    result = (int)cmd.ExecuteScalar();
                    t.Commit();
                    return result;
                }
            }
            catch (NpgsqlException ex)
            {
                if (ex.Code == "23505")
                {
                    return -23505;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return result;
        }
    }
}
