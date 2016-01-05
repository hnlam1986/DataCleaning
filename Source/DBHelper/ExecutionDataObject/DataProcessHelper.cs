using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DBHelper.ExecutionDataObject
{
    public class DataProcessHelper
    {
        DBExecution cmd = null;
        public DataProcessHelper()
        {
            cmd = new DBExecution();
        }
        public void InsertGoogleSuggest(string xml)
        {
            NpgsqlParameter param = new NpgsqlParameter("@xmlData", NpgsqlTypes.NpgsqlDbType.Text);
            param.Value = xml;
            cmd.ExcuteNoneQuery(DBConstant.InsertGoogleSuggest, new NpgsqlParameter[] { param });
        }

        public int SaveVerifyData(int management_id, int data_process_id, string add1, string add2, string add3, string add4,
            string user_name, string start_time, string end_time, double totaltime, string step, int data_id)
        {
            int res = 0;
            NpgsqlParameter param_data_process_id = new NpgsqlParameter("@data_process_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_data_process_id.Value = data_process_id;
            NpgsqlParameter param_management_id = new NpgsqlParameter("@management_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_management_id.Value = management_id;
            NpgsqlParameter param_add1 = new NpgsqlParameter("@address1", NpgsqlTypes.NpgsqlDbType.Text);
            param_add1.Value = add1;
            NpgsqlParameter param_add2 = new NpgsqlParameter("@address2", NpgsqlTypes.NpgsqlDbType.Text);
            param_add2.Value = add2;
            NpgsqlParameter param_add3 = new NpgsqlParameter("@address3", NpgsqlTypes.NpgsqlDbType.Text);
            param_add3.Value = add3;
            NpgsqlParameter param_add4 = new NpgsqlParameter("@address4", NpgsqlTypes.NpgsqlDbType.Text);
            param_add4.Value = add4;

            NpgsqlParameter param_user_name = new NpgsqlParameter("@user_name", NpgsqlTypes.NpgsqlDbType.Text);
            param_user_name.Value = user_name;
            NpgsqlParameter param_start_time = new NpgsqlParameter("@start_time", NpgsqlTypes.NpgsqlDbType.Text);
            param_start_time.Value = start_time;
            NpgsqlParameter param_end_time = new NpgsqlParameter("@end_time", NpgsqlTypes.NpgsqlDbType.Text);
            param_end_time.Value = end_time;
            NpgsqlParameter param_totaltime = new NpgsqlParameter("@totaltime", NpgsqlTypes.NpgsqlDbType.Double);
            param_totaltime.Value = totaltime;
            NpgsqlParameter param_step = new NpgsqlParameter("@step", NpgsqlTypes.NpgsqlDbType.Text);
            param_step.Value = step;
            NpgsqlParameter param_data_id = new NpgsqlParameter("@data_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_data_id.Value = data_id;
            res = cmd.ExecuteScalar(DBConstant.SaveVerifyData, new NpgsqlParameter[] { 
                param_management_id, param_data_process_id, param_add1, param_add2, param_add3, param_add4, 
                param_user_name, param_start_time, param_end_time,param_totaltime, param_step,param_data_id  
            });
            return res;
        }

        public int SaveQcData(int management_id, int data_process_id, string add1, string add2, string add3, string add4,
            string user_name, string start_time, string end_time, double totaltime, string step, int data_id)
        {
            int res = 0;
            NpgsqlParameter param_data_process_id = new NpgsqlParameter("@data_process_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_data_process_id.Value = data_process_id;
            NpgsqlParameter param_management_id = new NpgsqlParameter("@management_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_management_id.Value = management_id;
            NpgsqlParameter param_add1 = new NpgsqlParameter("@address1", NpgsqlTypes.NpgsqlDbType.Text);
            param_add1.Value = add1;
            NpgsqlParameter param_add2 = new NpgsqlParameter("@address2", NpgsqlTypes.NpgsqlDbType.Text);
            param_add2.Value = add2;
            NpgsqlParameter param_add3 = new NpgsqlParameter("@address3", NpgsqlTypes.NpgsqlDbType.Text);
            param_add3.Value = add3;
            NpgsqlParameter param_add4 = new NpgsqlParameter("@address4", NpgsqlTypes.NpgsqlDbType.Text);
            param_add4.Value = add4;

            NpgsqlParameter param_user_name = new NpgsqlParameter("@user_name", NpgsqlTypes.NpgsqlDbType.Text);
            param_user_name.Value = user_name;
            NpgsqlParameter param_start_time = new NpgsqlParameter("@start_time", NpgsqlTypes.NpgsqlDbType.Text);
            param_start_time.Value = start_time;
            NpgsqlParameter param_end_time = new NpgsqlParameter("@end_time", NpgsqlTypes.NpgsqlDbType.Text);
            param_end_time.Value = end_time;
            NpgsqlParameter param_totaltime = new NpgsqlParameter("@totaltime", NpgsqlTypes.NpgsqlDbType.Double);
            param_totaltime.Value = totaltime;
            NpgsqlParameter param_step = new NpgsqlParameter("@step", NpgsqlTypes.NpgsqlDbType.Text);
            param_step.Value = step;
            NpgsqlParameter param_data_id = new NpgsqlParameter("@data_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_data_id.Value = data_id;
            res = cmd.ExecuteScalar(DBConstant.SaveQcData, new NpgsqlParameter[] { 
                param_management_id, param_data_process_id, param_add1, param_add2, param_add3, param_add4, 
                param_user_name, param_start_time, param_end_time,param_totaltime, param_step,param_data_id  
            });
            return res;
        }

        public int SaveApproveData(int management_id, int data_process_id, string add1, string add2, string add3, string add4,
            string user_name, string start_time, string end_time, double totaltime, string step, int data_id)
        {
            int res = 0;
            NpgsqlParameter param_data_process_id = new NpgsqlParameter("@data_process_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_data_process_id.Value = data_process_id;
            NpgsqlParameter param_management_id = new NpgsqlParameter("@management_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_management_id.Value = management_id;
            NpgsqlParameter param_add1 = new NpgsqlParameter("@address1", NpgsqlTypes.NpgsqlDbType.Text);
            param_add1.Value = add1;
            NpgsqlParameter param_add2 = new NpgsqlParameter("@address2", NpgsqlTypes.NpgsqlDbType.Text);
            param_add2.Value = add2;
            NpgsqlParameter param_add3 = new NpgsqlParameter("@address3", NpgsqlTypes.NpgsqlDbType.Text);
            param_add3.Value = add3;
            NpgsqlParameter param_add4 = new NpgsqlParameter("@address4", NpgsqlTypes.NpgsqlDbType.Text);
            param_add4.Value = add4;

            NpgsqlParameter param_user_name = new NpgsqlParameter("@user_name", NpgsqlTypes.NpgsqlDbType.Text);
            param_user_name.Value = user_name;
            NpgsqlParameter param_start_time = new NpgsqlParameter("@start_time", NpgsqlTypes.NpgsqlDbType.Text);
            param_start_time.Value = start_time;
            NpgsqlParameter param_end_time = new NpgsqlParameter("@end_time", NpgsqlTypes.NpgsqlDbType.Text);
            param_end_time.Value = end_time;
            NpgsqlParameter param_totaltime = new NpgsqlParameter("@totaltime", NpgsqlTypes.NpgsqlDbType.Double);
            param_totaltime.Value = totaltime;
            NpgsqlParameter param_step = new NpgsqlParameter("@step", NpgsqlTypes.NpgsqlDbType.Text);
            param_step.Value = step;
            NpgsqlParameter param_data_id = new NpgsqlParameter("@data_id", NpgsqlTypes.NpgsqlDbType.Integer);
            param_data_id.Value = data_id;
            res = cmd.ExecuteScalar(DBConstant.SaveApproveData, new NpgsqlParameter[] { 
                param_management_id, param_data_process_id, param_add1, param_add2, param_add3, param_add4, 
                param_user_name, param_start_time, param_end_time,param_totaltime, param_step,param_data_id  
            });
            return res;
        }
        public int StartQCProcess()
        {
            int res = cmd.ExecuteScalar(DBConstant.GetPercentQCCard, null);
            return res;
        }

        public int ReturnCard(string step)
        {
            NpgsqlParameter param_step = new NpgsqlParameter("@step", NpgsqlTypes.NpgsqlDbType.Text);
            param_step.Value = step;
            int res = cmd.ExecuteScalar(DBConstant.ReturnCard, new NpgsqlParameter[] { param_step });
            return res;
        }

        public int ResetAllCard()
        {
            int res = cmd.ExecuteScalar(DBConstant.ResetAllData, null);
            return res;
        }
    }
}
