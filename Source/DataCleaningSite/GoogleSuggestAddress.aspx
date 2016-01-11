<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleSuggestAddress.aspx.cs" Inherits="DataCleaningSite.GoogleSuggestAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Google Suggest Address</title>
    <script type="text/javascript" src="/Script/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="/Script/utilities.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAEI-06k68gVFWchhceS8YQdbCrnKiCC5c&signed_in=true"></script>
    <script type="text/javascript" src="Script/GoogleAPI.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <input type="hidden" id="hidInternal" />
            <label id="Label1">Keyword search:</label><br />
            <label id="keyword"></label> <br />
            <input id="btnButton" type="button" value="Start" onclick="googleAPI.GetAddressData();" />
            <div id="res"></div>
        </div>
    </form>
    <script>
        var googleAPI = new GoogleAPI({ "addresses": [{ "id": 1, "address": "26, CÁCH MẠNG THÁNG 8,5" }, { "id": 2, "address": "0, , TỔ 18, NGUYỄN PHÚC" }, { "id": 3, "address": "THÔN DỊCH ĐỒNG, XÃ ĐỒNG CƯƠNG" }] });
        $(document).ready(function () {
            $("#btnButton").click();
            setInterval(function () {
                location.reload();
            }, 3600000);//3600000
        });
    </script>
</body>
</html>
