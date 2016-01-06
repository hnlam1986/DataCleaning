<%@ Page Title="" Language="C#" MasterPageFile="~/DataCleaning.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="DataCleaningSite.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--[if lte IE 7]>
    <div class="ie7">
<![endif]-->

    <div class="outer change-password">
        <div class="rightCornerLogo"></div>
        <div class="middle">
            <div class="inner">
                <div id="divLogin">
                    <div id="divLoginHeader">
                        <div id="divLoginHeaderText">Change Password</div>
                    </div>
                    <div id="divLoginBody">
                        <table>
                            <tr>
                                <td>New password: </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="text-box" TextMode="Password"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" CssClass="error-message"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>Re-type password: </td>
                                <td>
                                    <asp:TextBox ID="txtRetype" runat="server" CssClass="text-box" TextMode="Password"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtRetype" CssClass="error-message"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr><td></td><td>
                                <asp:Label ID="lblResMessage" runat="server" Text=""></asp:Label>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Retype password is incorrect" ControlToValidate="txtRetype" ControlToCompare="txtPassword" CssClass="error-message"></asp:CompareValidator>
                                
                                         </td><td></td></tr>
                            
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnChange" runat="server" Text="Change Password" OnClick="btnChange_Click" /></td>
                                <td></td>
                            </tr>

                        </table>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--[if lte IE 7]>
    </div>
<![endif]-->
</asp:Content>
