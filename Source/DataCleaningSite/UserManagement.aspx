<%@ Page Title="" Language="C#" MasterPageFile="~/DataCleaning.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="DataCleaningSite.UserManagement" %>

<%@ Register Src="~/Controls/SubMenu.ascx" TagPrefix="uc1" TagName="SubMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/easyui.css" />
    <script type="text/javascript" src="/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/Script/datagrid-filter.js"></script>
    <script type="text/javascript" src="/Script/UserManagement.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SubMenu runat="server" ID="SubMenu" ConfigurationUrl="~/Setting.aspx" />
    <div id="divSettingContent">
        <div id="create_user_form" class="easyui-panel" title="Create User">
            <table>
                <tr>
                    <td>User Name:</td>
                    <td>
                        <input id="txtUserName" class="text-box " type="text" /></td>
                    <td>
                        <label for="txtUserName" class="non-display"><span class="error-message">*</span></label>
                         <label id="dupUsernameMessage" class="error-message"></label>
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <input id="txtPassword" class="text-box" type="password"/></td>
                    <td><label for="txtPassword" class="non-display"><span class="error-message">*</span></label></td>
                </tr>
                <tr>
                    <td>Display Name:</td>
                    <td>
                        <input id="txtDisplayName" class="text-box" type="text" /></td>
                    <td><label for="txtDisplayName" class="non-display"><span class="error-message">*</span></label></td>
                </tr>
            </table>
            <div id="divRole">
                <table>
                    <tr>
                        <td>
                            <label for="ckVerify">
                                <span>Verify permission: </span>
                            </label>
                            <input type="checkbox" value="1" id="ckVerify" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label for="ckQc">
                                <span>QC permission: </span>
                            </label>
                            <input type="checkbox" value="2" id="ckQc" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label for="ckApprove">
                                <span>Approve permission: </span>
                            </label>
                            <input type="checkbox" value="3" id="ckApprove" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label for="ckSetting" >
                                <span>Setting permission: </span>
                            </label>
                            <input type="checkbox" value="4" id="ckSetting" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label for="ckActive" >
                                <span>Active: </span>
                            </label>
                            <input type="checkbox" value="4" id="ckActive" checked="checked"/></td>
                    </tr>
                    <tr>
                        <td>

                            <input type="button" value="Add User" id="btnAdd" onclick="userManagement.CreateUser();" data-action="add"/>
                            <input type="button" value="Cancle" id="btnCancel" onclick="userManagement.CancelUpdate();" class="non-display" />
                        </td>

                    </tr>
                </table>

            </div>
        </div>
        <div style="padding-top: 10px">
            <div id="user_table" class="easyui-panel" title="List of User">
                <table id="dgUser" class="easyui-datagrid" style="width: 100%; height: 250px"
                    url="ajax.aspx?action=get_user_data" method="get"
                    singleselect="true">
                    <thead>
                        <tr>
                            <th field="user_id" width="10%">User ID</th>
                            <th field="user_name" width="40%">User Name</th>
                            <th field="display_name" width="40%">Display Name</th>
                            <th field="function" width="10%" formatter="userManagement.SelectColumn"></th>

                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
    <script>

        var userManagement = new UserManagement();
        $(document).ready(function () {
            var dg = $("#dgUser").datagrid('enableFilter');
            userManagement.ListOfUser = $("#dgUser").datagrid('getData').rows;
            $('#form1').submit(function (e) {
                e.preventDefault();
                $(this).formvalidate({
                    failureMessages: false,
                    successMessages: false,
                    messageFailureClass: 'label label-important',
                    messageSuccessClass: 'label label-success',
                    onSuccess: function (form) {

                    }
                });
            });
        });

    </script>
</asp:Content>
