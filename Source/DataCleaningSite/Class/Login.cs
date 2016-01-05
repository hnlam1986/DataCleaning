using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBHelper.Entities;

namespace DataCleaningSite
{
    public class Login
    {
        public User UserLogin { get; set; }
        public bool HasLogin { get; set; }
        public Role UserRole { get; set; }
        public DateTime StartTime { get; set; }
        public Login()
        {

        }
        
    }

}