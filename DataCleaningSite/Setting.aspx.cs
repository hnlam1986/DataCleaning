using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DBHelper.Entities;
using DBHelper.ExecutionDataObject;


namespace DataCleaningSite
{
    public partial class Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigurationItemHelper config = new ConfigurationItemHelper();
                List<ConfigurationItem> lstConfig = config.GetAllConfig();
                Session[DataCleaningConstant.ConfigSession] = lstConfig;
                foreach (ConfigurationItem item in lstConfig)
                {
                    if (item.config_key == "qc_percent")
                    {
                        txtQcPercent.Text = item.config_value;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<ConfigurationItem> lstConfig = (List<ConfigurationItem>)Session[DataCleaningConstant.ConfigSession];
            foreach (ConfigurationItem item in lstConfig)
            {
                if (item.config_key == "qc_percent")
                {
                    item.config_value = txtQcPercent.Text;
                }
            }
            XElement xmlElements = new XElement("Configs", lstConfig.Select(i => new XElement("Config", i.ToXml())));
            string xml = HttpUtility.HtmlDecode(xmlElements.ToString());
            ConfigurationItemHelper helper = new ConfigurationItemHelper();
            int res = helper.SaveAllConfig(xml);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowResultQCPercent", "<script>SaveQcPercentMessage(" + (res > 0).ToString().ToLower() + ");</script>");
        }

        protected void btnStartQC_Click(object sender, EventArgs e)
        {
            DataProcessHelper dataProcessHelper = new DataProcessHelper();
            int res = dataProcessHelper.StartQCProcess();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowResultQCPercent", "<script>StartQcMessage(" + (res > 0).ToString().ToLower() + ");</script>");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            DataProcessHelper dataProcessHelper = new DataProcessHelper();
            string data = ddlStep.SelectedValue;
            int res = dataProcessHelper.ReturnCard(data);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowResultQCPercent", "<script>ReturnCardMessage(" + (res > 0).ToString().ToLower() + ");</script>");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            DataProcessHelper dataProcessHelper = new DataProcessHelper();
            string data = ddlStep.SelectedValue;
            int res = dataProcessHelper.ResetAllCard();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowResultQCPercent", "<script>ResetCardMessage(" + (res > 0).ToString().ToLower() + ");</script>");

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            FullCardInfoHelper helper = new FullCardInfoHelper();
            List<ExportData> lstExport = helper.GetExportData();
            if (lstExport.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=DataCleaningExport.xls");
                Response.ContentType = "application/ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GridView1.DataSource = lstExport;
                    GridView1.DataBind();
                    GridView1.RenderControl(hw);
                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
                
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}