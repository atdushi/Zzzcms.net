<%@ Page Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CMS.ChangePassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" 
        CancelDestinationPageUrl="~/Default.aspx" 
        ContinueDestinationPageUrl="~/Default.aspx">
    </asp:ChangePassword>
</asp:Content>
