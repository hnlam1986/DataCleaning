using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Entities;
using Npgsql;

namespace DBHelper.ExecutionDataObject
{
    public class UserHelper
    {
        DBExecution cmd = null;
        public UserHelper()
        {
            cmd = new DBExecution();
        }

        public User DoLogin(string userName, string password)
        {
            User result = null ;
            NpgsqlParameter paramUserName = new NpgsqlParameter("@login_username", NpgsqlTypes.NpgsqlDbType.Text);
            paramUserName.Value = userName;
            NpgsqlParameter paramPassword = new NpgsqlParameter("@login_password", NpgsqlTypes.NpgsqlDbType.Text);
            paramPassword.Value = password;
            List<User> lstUser = cmd.ExecuteDataAdapter<User>(DBConstant.GetUserInfo, new NpgsqlParameter[] { paramUserName, paramPassword });
            if (lstUser != null && lstUser.Count > 0)
            {
                result = lstUser.FirstOrDefault();
            }
            return result;
        }
        public List<User> GetAllActiveUser()
        {
            List<User> lstUser = cmd.ExecuteDataAdapter<User>(DBConstant.GetAllActiveUser, null);
            return lstUser;
        }

        public int InsertUserInfo(User user)
        {
            int res = 0;
            NpgsqlParameter param_user_name = new NpgsqlParameter("@param_user_name", NpgsqlTypes.NpgsqlDbType.Text);
            param_user_name.Value = user.user_name;
            NpgsqlParameter param_password = new NpgsqlParameter("@param_password", NpgsqlTypes.NpgsqlDbType.Text);
            param_password.Value = user.password;
            NpgsqlParameter param_role = new NpgsqlParameter("@param_role", NpgsqlTypes.NpgsqlDbType.Text);
            param_role.Value = user.role;
            NpgsqlParameter param_display_name = new NpgsqlParameter("@param_display_name", NpgsqlTypes.NpgsqlDbType.Text);
            param_display_name.Value = user.display_name;
            res = cmd.ExecuteScalar(DBConstant.InsertUser, new NpgsqlParameter[] { param_user_name, param_password, param_role, param_display_name });
            return res;
        }

        public int UpdateUserInfo(User user)
        {
            int res = 0;
            NpgsqlParameter param_user_id = new NpgsqlParameter("@param_user_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_user_id.Value = user.user_id;
            NpgsqlParameter param_password = new NpgsqlParameter("@param_password", NpgsqlTypes.NpgsqlDbType.Text);
            param_password.Value = user.password;
            NpgsqlParameter param_role = new NpgsqlParameter("@param_role", NpgsqlTypes.NpgsqlDbType.Text);
            param_role.Value = user.role;
            NpgsqlParameter param_display_name = new NpgsqlParameter("@param_display_name", NpgsqlTypes.NpgsqlDbType.Text);
            param_display_name.Value = user.display_name;
            NpgsqlParameter param_status = new NpgsqlParameter("@param_status", NpgsqlTypes.NpgsqlDbType.Boolean);
            param_status.Value = user.status;
            res = cmd.ExecuteScalar(DBConstant.UpdateUser, new NpgsqlParameter[] { param_user_id, param_password, param_role, param_display_name, param_status });
            return res;
        }
        public List<string> GetUsersByStep(string step)
        {
            List<string> result = null;
            NpgsqlParameter paramstep = new NpgsqlParameter("@step", NpgsqlTypes.NpgsqlDbType.Text);
            paramstep.Value = step;
            List<string> dt = cmd.ExecuteDataAdapter(DBConstant.GetUserByStep, new NpgsqlParameter[] { paramstep });
            return dt;
        }
    }
}
