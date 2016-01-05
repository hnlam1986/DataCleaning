using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DBHelper.Entities
{
    public class FullCardInfo
    {
        public int management_id { get; set; }
        public string step { get; set; }
        public string assignment { get; set; }
        public int status { get; set; }
        public int data_id { get; set; }
        public string address { get; set; }
        public string adrress_correct { get; set; }
        public string adrress_correct1 { get; set; }
        public string adrress_correct2 { get; set; }
        public string adrress_correct3 { get; set; }
        public string adrress_correct4 { get; set; }
        public int data_process_id { get; set; }
        public string verify_address1 { get; set; }
        public string verify_address2 { get; set; }
        public string verify_address3 { get; set; }
        public string verify_address4 { get; set; }
        public string qc_address1 { get; set; }
        public string qc_address2 { get; set; }
        public string qc_address3 { get; set; }
        public string qc_address4 { get; set; }
        public string approve_address1 { get; set; }
        public string approve_address2 { get; set; }
        public string approve_address3 { get; set; }
        public string approve_address4 { get; set; }
        public string cleaning_address1 { get; set; }
        public string cleaning_address2 { get; set; }
        public string cleaning_address3 { get; set; }
        public string cleaning_address4 { get; set; }
        public string full_cleaning_address { get; set; }
        public string google_suggest { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }


    }

    public class FullCardInfoHelper
    {
        DBExecution cmd = null;
        public FullCardInfoHelper()
        {
            cmd = new DBExecution();
        }

        public List<FullCardInfo> GetProcessData(string userName, string step)
        {
            NpgsqlParameter paramUserName = new NpgsqlParameter("@user_name", NpgsqlTypes.NpgsqlDbType.Text);
            paramUserName.Value = userName;
            NpgsqlParameter paramstep = new NpgsqlParameter("@step", NpgsqlTypes.NpgsqlDbType.Text);
            paramstep.Value = step;
            List<FullCardInfo> dt = cmd.ExecuteDataAdapter<FullCardInfo>(DBConstant.GetDataStep, new NpgsqlParameter[] { paramUserName, paramstep });
            return dt;
        }

        public List<ExportData> GetExportData()
        {
            List<ExportData> dt = cmd.ExecuteDataAdapter<ExportData>(DBConstant.GetExportData, null);
            return dt;
        }
    }
}
