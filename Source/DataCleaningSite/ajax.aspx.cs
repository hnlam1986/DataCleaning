using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using DBHelper.Entities;
using DBHelper.ExecutionDataObject;
using Newtonsoft.Json;

namespace DataCleaningSite
{
    public partial class ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["action"] ?? Request.Form["action"];
            switch (action)
            {
                case "get_address_data":
                    GetAddressData();
                    break;
                case "update_address_suggest":
                    UpdateAddressSuggest();
                    break;
                case "get_process_data":
                    string step = Request.QueryString["step"];
                    GetProcessData(step);
                    break;
                case "save_verify_data":
                    SaveVerifyData();
                    break;
                case "save_qc_data":
                    SaveQcData();
                    break;
                case "save_approve_data":
                    SaveApproveData();
                    break;
                case "get_user_data":
                    GetAllActiveUser();
                    break;
                case "insert_user_data":
                    InsertUserData();
                    break;

                case "update_user_data":
                    UpdateUserData();
                    break;
                case "get_working_status":
                    GetWorkingStatus();
                    break;

            }
        }
        private void GetWorkingStatus()
        {
            Login login = (Login)Session[DataCleaningConstant.LoginInfoSession];
            string step = Request.QueryString["step"];
            WorkingStatusHelper working = new WorkingStatusHelper();
            WorkingStatus status = working.GetWorkingStatus(login.UserLogin.user_name, step);
            status.total_time = Math.Round(status.total_time, 1);
            status.speed = Math.Round(status.speed, 1);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(status);
            Response.Write(json);
            Response.End();
        }
        private void GetAllActiveUser()
        {
            List<User> users = null;
            UserHelper hepler = new UserHelper();
            users = hepler.GetAllActiveUser();
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(users);
            Response.Write(json);
            Response.End();
        }
        private void GetAddressData()
        {
            string data = Request.QueryString["data"];
            DataHelper dataHelper = new DataHelper();
            List<Data> lstData = dataHelper.GetAllData(data);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(lstData);
            Response.Write(json);
            Response.End();
        }
        private void UpdateAddressSuggest()
        {
            string data = Request.Form["data"];
            XmlDocument doc = JsonConvert.DeserializeXmlNode("{\"Address\":" +  data + "}", "Addresses");
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            doc.WriteTo(tx);
            string xmlData = sw.ToString();
            DataProcessHelper dataProcessHelper = new DataProcessHelper();
            dataProcessHelper.InsertGoogleSuggest(xmlData);
        }
        private void GetProcessData(string step)
        {
            FullCardInfoHelper dataHelper = new FullCardInfoHelper();
            Login login = (Login)Session[DataCleaningConstant.LoginInfoSession];
            List<FullCardInfo> lstData = dataHelper.GetProcessData(login.UserLogin.user_name, step);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(lstData);
            Response.Write(json);
            Response.End();
        }

        private void SaveVerifyData()
        {
            string data = Request.Form["data"];
            Login login = (Login)Session[DataCleaningConstant.LoginInfoSession];
            var jsonSerialiser = new JavaScriptSerializer();
            FullCardInfo info = jsonSerialiser.Deserialize<FullCardInfo>(data);
            if (info != null)
            {
                info.verify_address1 = HttpUtility.HtmlDecode(info.verify_address1);
                info.verify_address2 = HttpUtility.HtmlDecode(info.verify_address2);
                info.verify_address3 = HttpUtility.HtmlDecode(info.verify_address3);
                info.verify_address4 = HttpUtility.HtmlDecode(info.verify_address4);
            }
            DataProcessHelper dataProcessHelper = new DataProcessHelper();
            TimeSpan totalTime = DateTime.Parse(info.endtime).Subtract(DateTime.Parse(info.starttime));
            double total = totalTime.TotalSeconds;
            int result = dataProcessHelper.SaveVerifyData(info.management_id, info.data_process_id, info.verify_address1, info.verify_address2, info.verify_address3, 
                info.verify_address4, login.UserLogin.user_name, info.starttime, info.endtime, total, info.step, info.data_id, info.cleaning_address1
                , info.cleaning_address2, info.cleaning_address3, info.cleaning_address4, info.full_cleaning_address);
            Response.Write(result.ToString());
            Response.End();
        }
        
        private void SaveQcData()
        {
            string data = Request.Form["data"];
            Login login = (Login)Session[DataCleaningConstant.LoginInfoSession];
            var jsonSerialiser = new JavaScriptSerializer();
            FullCardInfo info = jsonSerialiser.Deserialize<FullCardInfo>(data);
            if (info != null)
            {
                info.qc_address1 = HttpUtility.HtmlDecode(info.qc_address1);
                info.qc_address2 = HttpUtility.HtmlDecode(info.qc_address2);
                info.qc_address3 = HttpUtility.HtmlDecode(info.qc_address3);
                info.qc_address4 = HttpUtility.HtmlDecode(info.qc_address4);
            }
            DataProcessHelper dataProcessHelper = new DataProcessHelper();
            TimeSpan totalTime = DateTime.Parse(info.endtime).Subtract(DateTime.Parse(info.starttime));
            double total = totalTime.TotalSeconds;
            int result = dataProcessHelper.SaveQcData(info.management_id, info.data_process_id, info.qc_address1, info.qc_address2, info.qc_address3, info.qc_address4, login.UserLogin.user_name, info.starttime, info.endtime, total, info.step, info.data_id);
            Response.Write(result.ToString());
            Response.End();
        }

        private void SaveApproveData()
        {
            string data = Request.Form["data"];
            Login login = (Login)Session[DataCleaningConstant.LoginInfoSession];
            var jsonSerialiser = new JavaScriptSerializer();
            FullCardInfo info = jsonSerialiser.Deserialize<FullCardInfo>(data);
            if (info != null)
            {
                info.approve_address1 = HttpUtility.HtmlDecode(info.approve_address1);
                info.approve_address2 = HttpUtility.HtmlDecode(info.approve_address2);
                info.approve_address3 = HttpUtility.HtmlDecode(info.approve_address3);
                info.approve_address4 = HttpUtility.HtmlDecode(info.approve_address4);
            }
            DataProcessHelper dataProcessHelper = new DataProcessHelper();
            TimeSpan totalTime = DateTime.Parse(info.endtime).Subtract(DateTime.Parse(info.starttime));
            double total = totalTime.TotalSeconds;
            int result = dataProcessHelper.SaveApproveData(info.management_id, info.data_process_id, info.approve_address1, info.approve_address2, info.approve_address3, info.approve_address4, login.UserLogin.user_name, info.starttime, info.endtime, total, info.step, info.data_id);
            Response.Write(result.ToString());
            Response.End();
        }

        private void InsertUserData()
        {
            string data = Request.Form["data"];
            var jsonSerialiser = new JavaScriptSerializer();
            User info = jsonSerialiser.Deserialize<User>(data);
            UserHelper hepler = new UserHelper();
            info.password = Utilities.EncryptMD5(info.password);
            int res = hepler.InsertUserInfo(info);
            Response.Write(res.ToString());
            Response.End();
        }

        private void UpdateUserData()
        {
            string data = Request.Form["data"];
            var jsonSerialiser = new JavaScriptSerializer();
            User info = jsonSerialiser.Deserialize<User>(data);
            UserHelper hepler = new UserHelper();
            info.password = info.password != "" ? Utilities.EncryptMD5(info.password) : "";
            int res = hepler.UpdateUserInfo(info);
            Response.Write(res.ToString());
            Response.End();
        }

        private void DeleteUserData()
        {
            string data = Request.Form["data"];
            var jsonSerialiser = new JavaScriptSerializer();
            User info = jsonSerialiser.Deserialize<User>(data);
            info.status = false;
            UserHelper hepler = new UserHelper();
            int res = hepler.UpdateUserInfo(info);
            Response.Write(res.ToString());
            Response.End();
        }

        //private void ReturnCard()
        //{
        //    string data = Request.Form["data"];
        //    DataProcessHelper dataProcessHelper = new DataProcessHelper();
        //    int res = dataProcessHelper.ReturnCard(data);
        //    Response.Write(res.ToString());
        //    Response.End();
        //}
    }
}