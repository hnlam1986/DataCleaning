using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Entities;

namespace DBHelper.ExecutionDataObject
{
    public class DataHelper
    {
        DBExecution cmd = null;
        public DataHelper()
        {
            cmd = new DBExecution();
        }

        public List<Data> GetAllData()
        {
            List<Data> dt = cmd.ExecuteDataAdapter<Data>(DBConstant.GetAllData,null);
            return dt;
        }

        
    }
}
