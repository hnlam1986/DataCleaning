﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Entities
{
    public class Data
    {
        public int data_id { get; set; }
        public int management_id { get; set; }
        public string appl_id { get; set; }
        public string address_id { get; set; }
        public string cust_id { get; set; }
        public string cust_type { get; set; }
        public string address_type { get; set; }
        public string state_desc { get; set; }
        public string country_lms { get; set; }
        public string city_lms { get; set; }
        public string flag { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string address4 { get; set; }
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
        public string complete_adrress_correct
        {
            get
            {
                return adrress_correct + ", " + city_lms + ", " + state_desc + ", " + country_lms;
            }
        }
        public string adrress_correct1 { get; set; }
        public string adrress_correct2 { get; set; }
        public string adrress_correct3 { get; set; }
        public string adrress_correct4 { get; set; }
        public string processed_dttm { get; set; }

    }
}
