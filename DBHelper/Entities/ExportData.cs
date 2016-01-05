using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Entities
{
    public class ExportData
    {
        public string appl_id { get; set; }
        public string address_id { get; set; }
        public string cust_id { get; set; }
        public string cust_type { get; set; }
        public string address_type { get; set; }
        public string state_desc { get; set; }
        public string country_lms { get; set; }
        public string city_lms { get; set; }
        public string flag { get; set; }
        public string address { get; set; }
        public string adrress_correct
        {
            get
            {
                string res = "";
                if (adrress_correct1 != null)
                {
                    res += adrress_correct1 + ", ";
                }
                if (adrress_correct2 != null)
                {
                    res += adrress_correct2 + ", ";
                }
                if (adrress_correct3 != null)
                {
                    res += adrress_correct3 + ", ";
                }
                if (adrress_correct4 != null)
                {
                    res += adrress_correct4;
                }
                return res;
            }

        }
        public string address1 { get; set; }
        public string adrress_correct1 { get; set; }
        public string address2 { get; set; }
        public string adrress_correct2 { get; set; }
        public string address3 { get; set; }
        public string adrress_correct3 { get; set; }
        public string address4 { get; set; }
        public string adrress_correct4 { get; set; }
        public string processed_dttm { get; set; }

    }
}
