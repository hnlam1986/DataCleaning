using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Entities;
using Npgsql;

namespace DBHelper.ExecutionDataObject
{
    public class DataHelper
    {
        DBExecution cmd = null;
        public DataHelper()
        {
            cmd = new DBExecution();
        }

        public List<Data> GetAllData(string session)
        {
            NpgsqlParameter param = new NpgsqlParameter("@sessionName", NpgsqlTypes.NpgsqlDbType.Text);
            param.Value = session;
            List<Data> dt = cmd.ExecuteDataAdapter<Data>(DBConstant.GetAllData, new NpgsqlParameter[] { param });
            return dt;
        }

        
    }
}
