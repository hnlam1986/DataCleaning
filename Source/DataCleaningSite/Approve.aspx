<%@ Page Title="" Language="C#" MasterPageFile="~/DataCleaning.Master" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="DataCleaningSite.Approve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/easyui.css" />
    <script type="text/javascript" src="/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.blockUI.js"></script>
    <script type="text/javascript" src="/Script/jquery.highlight.js"></script>
    <script type="text/javascript" src="/Script/jquery.caret.1.02.min.js"></script>
    <script type="text/javascript" src="/Script/ProcessForm.js"></script>
    <script type="text/javascript" src="/Script/shortcut.js"></script>
    <script type="text/javascript" src="/Script/diff_match_patch.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="MainContainBody" class="easyui-layout">
        <div data-options="region:'west',split:true" title="Original Data" style="width: 300px;" id="divLeft">
        </div>
        <div data-options="region:'center',iconCls:'icon-ok'" id="divRight" >
            <div class="text-field-panel">
                <%-- Verify section --%>
                <div class="panel-header">
                    <div class="panel-title">Verify Data</div>
                </div>
                <div class="panel-contain" id="divCleaningData">
                    <div id="fullOriginalAddressContain">
                        <label id="Label2">Original address: </label>
                        <label id="lblOriginalFullAddress" class="bold-text"></label><label id="Label3" class="lblCity bold-text" ></label>
                    </div>
                    <div id="fullAddressContain">
                        <label id="lblFullAddress">Full address: </label>
                        <label id="lblFullAddressValue" class="bold-text"></label><label id="lblCity" class="lblCity bold-text"></label>
                    </div>
                    <table cellspacing="10">
                        <tr>
                            <td>ADDRESS1 [Số]:</td>
                            <td>
                                <input type="text" id="txtAddress1" class="login-textbox" readonly="true" tabindex="1"/></td>
                            <td>ADDRESS3 [Phường/Xã/Thị trấn]:</td>
                            <td>
                                <input type="text" id="txtAddress3" class="login-textbox" readonly="true" tabindex="3"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>ADDRESS2 [Tên đường/khóm/Thôn/Ấp/Tổ]:</td>
                            <td>
                                <input type="text" id="txtAddress2" class="login-textbox" readonly="true" tabindex="2"/></td>
                            <td>ADDRESS4 [Quận/Huyện/Thị xã]:</td>
                            <td>
                                <input type="text" id="txtAddress4" class="login-textbox" readonly="true" tabindex="4"/></td>
                            <td>
                        </tr>
                    </table>
                    

                </div>

                <%-- QC/Approve data --%>
                <div class="panel-header margin-top-10px" >
                    <div class="panel-title">QC Data / Approve Data</div>
                </div>
                <div class="panel-contain " id="div1">
                    <div id="Div3" class="margin-left-10px">
                        <label id="Label4">Original address: </label>
                        <label id="lblQcOriginalFullAddress" class="bold-text"></label><label id="Label6" class="lblCity bold-text" ></label>
                    </div>
                    <div id="Div2" class="margin-left-10px margin-top-13px">
                        <label id="Label1">Full address: </label>
                        <label id="lblFullApprove" class="bold-text"></label><label id="Label5" class="lblCity bold-text" ></label>
                    </div>
                    <div id="Div4" class="margin-left-10px margin-top-13px">
                        <table>
                            <tr>
                                <td>Comparation: </td><td><div id="comparation_output" style="float:left"></div></td>
                            </tr>
                        </table>
                    </div>
                    <table cellspacing="10">
                        <tr>
                            <td>ADDRESS1 [Số]:</td>
                            <td>
                                <input type="text" id="txtApprove1" class="login-textbox" tabindex="5"/></td>
                            <td>ADDRESS3 [Phường/Xã/Thị trấn]:</td>
                            <td>
                                <input type="text" id="txtApprove3" class="login-textbox" tabindex="7"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>ADDRESS2 [Tên đường/khóm/Thôn/Ấp/Tổ]:</td>
                            <td>
                                <input type="text" id="txtApprove2" class="login-textbox" tabindex="6"/></td>
                            <td>ADDRESS4 [Quận/Huyện/Thị xã]:</td>
                            <td>
                                <input type="text" id="txtApprove4" class="login-textbox" tabindex="8"/></td>
                            <td>
                                <input type="button" value="Next Card" disabled="disabled" id="btnSave"/></td>
                        </tr>
                    </table>
                    <label id="lblMessage"> </label>

                </div>

                <div class="panel-header margin-top-10px" id="pnlGoogleSuggest">
                    <div class="panel-title">Google Suggestion</div>
                    <a class="btnGooglePopup" href="#" onclick="processForm.OpenGoogleSearch()" ></a>
                </div>
                <div class="" id="googleSuggest">
                    <div id="googleSuggestResult"></div>
                    
                </div>
            </div>
        </div>
        <div data-options="region:'south',split:true" title="Google Search"  id="divGoogle" style="height: 40%;">
            <iframe id="ifGoogleEmbed" width="100%" height="100%" style="visibility:visible" src="http://www.google.com.vn/custom?q="></iframe>
        </div>
        <script>
            var processForm = new ProcessForm('approve');
            $(document).ready(function () {
                processForm.LoadProcessCard($("#divLeft"));
            });
        </script>
</asp:Content>
