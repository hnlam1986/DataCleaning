<%@ Page Title="" Language="C#" MasterPageFile="~/DataCleaning.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="DataCleaningSite.Setting" %>

<%@ Register Src="~/Control/SubMenu.ascx" TagPrefix="uc1" TagName="SubMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SubMenu runat="server" id="SubMenu" UserManagementUrl="~/UserManagement.aspx" />
    <div id="divSettingContent">
        <table>
            <tr>
                <td>QC percent:</td><td><asp:TextBox ID="txtQcPercent" runat="server" CssClass="qc-percent-text-box"></asp:TextBox>(%)</td>
            </tr>
            <tr>
                <td></td><td><asp:Button ID="btnSave" runat="server" Text="Save Configuration" OnClick="btnSave_Click" /><asp:Button ID="btnStartQC" runat="server" Text="Start QC" OnClick="btnStartQC_Click" /></td>
            </tr>
        </table>

    </div>
</asp:Content>
