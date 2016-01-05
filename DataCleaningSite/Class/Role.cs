using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCleaningSite
{
    public class Role
    {
        public bool HasVerifyRole { get; set; }
        public bool HasQCRole { get; set; }
        public bool HasApproveRole { get; set; }
        public bool HasSettingRole { get; set; }
        public Role()
        {

        }
        public Role(string role)
        {
            string[] roles = role.Split('|');
            if (roles[0] == "1")
            {
                HasVerifyRole = true;
            }
            if (roles[1] == "1")
            {
                HasQCRole = true;
            }
            if (roles[2] == "1")
            {
                HasApproveRole = true;
            }
            if (roles[3] == "1")
            {
                HasSettingRole = true;
            }
        }
    }

}