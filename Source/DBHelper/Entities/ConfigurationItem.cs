using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Npgsql;

namespace DBHelper.Entities
{
    [Serializable]
    public class ConfigurationItem
    {
        public int config_id { get; set; }
        public string config_key { get; set; }
        public string config_value { get; set; }
        public ConfigurationItem()
        {

        }
        public string ToXml()
        {
            string xml = string.Format( "<config_id>{0}</config_id><config_key>{1}</config_key><config_value>{2}</config_value>",this.config_id, this.config_key, this.config_value);
            return xml;
        }
    }
    public class ConfigurationItemHelper
    {
        DBExecution cmd = null;
        public ConfigurationItemHelper()
        {
            cmd = new DBExecution();
        }
        public List<ConfigurationItem> GetAllConfig()
        {
            List<ConfigurationItem> result = null;
            result = cmd.ExecuteDataAdapter<ConfigurationItem>(DBConstant.GetAllConfig, null);
            return result;
        }
        public int SaveAllConfig(string xml)
        {
            int res = 0;
            NpgsqlParameter param = new NpgsqlParameter("@xmlData", NpgsqlTypes.NpgsqlDbType.Text);
            param.Value = xml;
            res = cmd.ExecuteScalar(DBConstant.UpdateAllConfig, new NpgsqlParameter[] { param });
            return res;
        }
    }
}
