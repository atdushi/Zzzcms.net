<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CMS.LogOn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link href="Images/cms.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <img alt="" src="Images/logo.png" style="width: 345px; height: 105px" />
            <br />
            BACKEND OF YOUR SYSTEM
            <br />
            <br />
            <asp:Login ID="LoginN" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
                ForeColor="#333333">
                <TextBoxStyle Font-Size="0.8em" />
                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            </asp:Login>
        </center>
    </div>
    </form>
</body>
</html>
