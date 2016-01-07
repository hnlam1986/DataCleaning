<%@ Page Title="" Language="C#" MasterPageFile="~/DataCleaning.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="DataCleaningSite.Setting" %>

<%@ Register Src="~/Controls/SubMenu.ascx" TagPrefix="uc1" TagName="SubMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SubMenu runat="server" ID="SubMenu" UserManagementUrl="~/UserManagement.aspx" />
    <div id="divSettingContent">
        <div id="divGoogleSuggest">
            <table>
                <tr>
                    <td>Open Google Suggestion:</td>
                    <td>
                        <input id="btnGoogle" value="Open new window" type="button"  onclick="openSessionGoogleSuggest();"/>
                        
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        </div>
        <div id="divQCSetting">
            <table>
                <tr>
                    <td>QC percent:</td>
                    <td>
                        <asp:TextBox ID="txtQcPercent" runat="server" CssClass="qc-percent-text-box"></asp:TextBox>(%)

                    </td>
                    <td><div id="qcMessageContent"></div></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save Configuration" OnClick="btnSave_Click" /><asp:Button ID="btnStartQC" runat="server" Text="Start QC" OnClick="btnStartQC_Click" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div id="divReturnCard">
            <table>
                <tr>
                    <td>Return card for Step:</td>
                    <td>
                        <asp:DropDownList ID="ddlStep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStep_SelectedIndexChanged" Width="100px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="verify">Verify</asp:ListItem>
                            <asp:ListItem Value="qc">QC</asp:ListItem>
                            <asp:ListItem Value="approve">Approve</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlUser" runat="server" Width="100px"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnReturn" runat="server" Text="Return Card" OnClick="btnReturn_Click" />
                        
                    </td>
                    <td>
                        <div id="ReturnMessageContent"></div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divResetAllData">
            <table>
                <tr>
                    <td>Reset all data:</td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset All Data" OnClick="btnReset_Click" />
                        
                    </td>
                    <td>
                        <div id="ResetMessageContent"></div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divExportData">
            <table>
                <tr>
                    <td>Export all data:</td>
                    <td>
                        <asp:Button ID="btnExport" runat="server" Text="Export All Data" OnClick="btnExport_Click"  />
                        
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        
    </div>
</asp:Content>
