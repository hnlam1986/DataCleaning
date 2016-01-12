using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
        private string _address = "";
        public string address
        {
            get
            {
                if (_address == null || _address == "")
                {
                    string res = "";
                    if (address1 != null)
                    {
                        res += address1 + ", ";
                    }
                    if (address2 != null)
                    {
                        res += address2 + ", ";
                    }
                    if (address3 != null)
                    {
                        res += address3 + ", ";
                    }
                    if (address4 != null)
                    {
                        res += address4;
                    }
                    _address = res;
                }
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string address4 { get; set; }
        public string city_lms { get; set; }
        public string state_desc { get; set; }
        public string country_lms { get; set; }
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
        private string _cleaning_address1 = "";
        private string _cleaning_address2 = "";
        private string _cleaning_address3 = "";
        private string _cleaning_address4 = "";
        private string _full_cleaning_address = "";


        public string cleaning_address1 { get { return HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(_cleaning_address1)); } set { _cleaning_address1 = value; } }
        public string cleaning_address2 { get { return HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(_cleaning_address2)); } set { _cleaning_address2 = value; } }
        public string cleaning_address3 { get { return HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(_cleaning_address3)); } set { _cleaning_address3 = value; } }
        public string cleaning_address4 { get { return HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(_cleaning_address4)); } set { _cleaning_address4 = value; } }
        public string full_cleaning_address { get { return HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(_full_cleaning_address)); } set { _full_cleaning_address = value; } }
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
