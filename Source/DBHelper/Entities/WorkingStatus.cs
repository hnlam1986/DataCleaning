using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DBHelper.Entities
{
    public class WorkingStatus
    {
        public int total_card { get; set; }
        public decimal total_time { get; set; }
        public decimal speed { get; set; }
    }
    public class WorkingStatusHelper
    {
        DBExecution cmd = null;
        public WorkingStatusHelper()
        {
            cmd = new DBExecution();
        }

        public WorkingStatus GetWorkingStatus(string username, string step)
        {
            NpgsqlParameter paramUser = new NpgsqlParameter("@userName", NpgsqlTypes.NpgsqlDbType.Text);
            paramUser.Value = username;
            NpgsqlParameter paramStep = new NpgsqlParameter("@userstep", NpgsqlTypes.NpgsqlDbType.Text);
            paramStep.Value = step;
            List<WorkingStatus> dt = cmd.ExecuteDataAdapter<WorkingStatus>(DBConstant.GetWorkingStatus, new NpgsqlParameter[] { paramUser, paramStep });
            if (dt != null && dt.Count > 0)
            {
                return dt.FirstOrDefault();
            }
            return null ;
        }
    }
}
