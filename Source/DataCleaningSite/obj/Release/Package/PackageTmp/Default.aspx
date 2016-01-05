<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataCleaningSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data Cleaning</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainCSS.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!--[if lte IE 7]>
    <div class="ie7">
<![endif]-->

        <div class="outer">
            <div class="rightCornerLogo"></div>
            <div class="middle">
                <div class="inner">
                    <div id="divLogin">
                        <div id="divLoginHeader">
                            <div id="divLoginHeaderText">login</div>
                        </div>
                        <div id="divLoginBody">
                            <div id="divUserName" class="padding-top-5px">
                                User name:<asp:RequiredFieldValidator ID="valUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                                <div id="divUserNameTextBox" >
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="login-textbox"></asp:TextBox>
                                </div>
                            </div>
                            <div id="divPassword" class="padding-top-5px">
                                Password:<asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                <div id="divPasswordTextBox">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="login-textbox" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div id="divLoginSubmit" class="padding-top-5px">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-submit-button" OnClick="btnLogin_Click"/>

                            </div>
                            <div class="errorMessage">
                                <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--[if lte IE 7]>
    </div>
<![endif]-->
    </form>
</body>
</html>
