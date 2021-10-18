<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile/Site.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.Encode(ViewData["Message"]) %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
