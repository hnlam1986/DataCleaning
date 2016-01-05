using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public static class DBConstant
    {
        public const string _schema = "data_cleaning";
        #region "Functions"
        public const string GetAllData = "get_all_data";
        public const string InsertGoogleSuggest = "insert_google_suggest";
        public const string GetUserInfo = "get_user_info";
        public const string SaveVerifyData = "save_verify_data";
        public const string SaveQcData = "save_qc_data";
        public const string SaveApproveData = "save_approve_data";
        public const string GetDataStep = "get_data_step";
        public const string GetAllConfig = "get_all_config";
        public const string UpdateAllConfig = "update_all_config";
        public const string GetPercentQCCard = "get_percent_qc_card";
        public const string GetAllActiveUser = "get_all_user_info";
        public const string InsertUser = "insert_user";
        public const string UpdateUser = "update_user";
        public const string ReturnCard = "return_card_by_step";
        public const string ResetAllData = "reset_all_data";
        public const string GetExportData = "get_export_data";
        
        #endregion
        public static string Schema
        {
            get {
                string schema = ConfigurationSettings.AppSettings.Get("DBSchema");
                if (schema != "")
                {
                    return schema;
                }
                return _schema;
            }
        }
        public static string BuildStoreName(string storeName)
        {
            return Schema + "." + storeName;
        }
    }
}
