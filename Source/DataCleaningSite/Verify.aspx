﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DataCleaning.Master" AutoEventWireup="true" CodeBehind="QC.aspx.cs" Inherits="DataCleaningSite.QC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/easyui.css" />
    <script type="text/javascript" src="/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/Script/jquery.blockUI.js"></script>
    <script type="text/javascript" src="/Script/jquery.highlight.js"></script>
    <script type="text/javascript" src="/Script/jquery.caret.1.02.min.js"></script>
    <script type="text/javascript" src="/Script/shortcut.js"></script>
    <script type="text/javascript" src="/Script/ProcessForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="MainContainBody" class="easyui-layout">
        <div data-options="region:'west',split:true" title="Original Data" style="width: 300px;" id="divLeft">
        </div>
        <div data-options="region:'center',iconCls:'icon-ok'" id="divRight" >
            <div class="text-field-panel">
                <div class="panel-header">
                    <div class="panel-title">Cleaning Data<div id="working_status"></div></div>
                </div>
                <div class="panel-contain" id="divCleaningData">
                    <div id="fullOriginalAddressContain">
                        <label id="Label1">Original address: </label>
                        <label id="lblOriginalFullAddress" class="bold-text"></label><label id="Label2" class="lblCity bold-text" ></label>
                    </div>
                    <div id="fullAddressContain">
                        <label id="lblFullAddress">Full address: </label>
                        <label id="lblFullAddressValue" class="bold-text"></label><label id="lblCity" class="lblCity bold-text"></label>
                    </div>
                    <table cellspacing="10" style="width:100%">
                        <tr>
                            <td style="width:150px"><b>ADDRESS1</b> [Số]:</td>
                            <td style="width:auto">
                                <input type="text" id="txtAddress1" class="process-textbox" tabindex="1"/></td>
                            <td style="width:150px"><b>ADDRESS3</b> [Phường<span class="hotkey">(5)</span>/<br />Xã<span class="hotkey">(6)</span>/Thị trấn<span class="hotkey">(7)</span>]:</td>
                            <td  style="width:auto">
                                <input type="text" id="txtAddress3" class="process-textbox" tabindex="3"/></td>
                            <td style="width:100px">
                                <input type="button" value="Next Card" disabled="disabled" id="btnSave" tabindex="5" class="process-button"/>
                            </td>
                        </tr>
                        <tr>
                            <td><b>ADDRESS2</b> [Tên Đường/ Khóm<span class="hotkey">(1)</span>/Thôn<span class="hotkey">(2)</span>/Ấp<span class="hotkey">(3)</span> /Tổ<span class="hotkey">(4)</span>]:</td>
                            <td>
                                <input type="text" id="txtAddress2" class="process-textbox" tabindex="2"/></td>
                            <td><b>ADDRESS4</b> [Quận<span class="hotkey">(8)</span>/<br />Huyện<span class="hotkey">(9)</span>/Thị xã<span class="hotkey">(0)</span>]:</td>
                            <td>
                                <input type="text" id="txtAddress4" class="process-textbox" tabindex="4"/></td>
                            <td>
                                
                                <input type="button" value="Previous Card"  id="btnPrevious" tabindex="6" onclick="processForm.GetPreviousCard();" disabled="disabled" class="process-button"/>
                            </td>
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
        <%--<div data-options="region:'south',split:true" title="Google Search"  id="divGoogle" style="height: 40%;">
            <iframe id="ifGoogleEmbed" width="100%" height="100%" style="visibility:visible" src=""></iframe>
        </div>--%>
        <script>

            var processForm = new ProcessForm('verify');
            $(document).ready(function () {
                processForm.LoadProcessCard($("#divLeft"));
            });
        </script>
</asp:Content>
