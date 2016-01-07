using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DBHelper.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
        public string role { get; set; }
        public string display_name { get; set; }
    }

    
}
