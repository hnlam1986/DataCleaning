<%@ Page Title="" Language="C#" MasterPageFile="~/DataCleaning.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DataCleaningSite.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--[if lte IE 7]>
    <div class="ie7">
<![endif]-->

        <div class="outer">
            <div class="rightCornerLogo"></div>
            <div class="middle">
                <div class="inner">
                    <div id="divLogin">
                        <div id="divLoginHeader">
                            <div id="divLoginHeaderText">login information</div>
                        </div>
                        <div id="divLoginBody">
                            <div id="divUserName" class="padding-top-5px">
                                Dispaly Name:<asp:Label ID="lblDisplayname" runat="server" Text=""></asp:Label>
                            </div>
                            <div id="divPassword" class="padding-top-5px">
                                Start Time:<asp:Label ID="lblStarttime" runat="server" Text=""></asp:Label>
                            </div>
                            <div id="divLoginSubmit" class="padding-top-5px">
                                <a href="/default.aspx?logout=true">Logout</a> | <a href="/changepassword.aspx">Change Password</a>

                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--[if lte IE 7]>
    </div>
<![endif]-->
</asp:Content>
