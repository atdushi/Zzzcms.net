<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="Controllers.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Feedback
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form method="post" action="/Home/SendFeedback">
    <%= Html.ValidationSummary() %>
    <fieldset>
        <legend>Send feedback:</legend>
        <table>
            <tr>
                <td align="right">
                    <label for="tbName">
                        Name:</label>
                </td>
                <td>
                    <%= Html.TextBox("Name")%>
                    <%= Html.ValidationMessage("Name", "*") %>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label for="tbEmail">
                        Email:</label>
                </td>
                <td>
                    <%= Html.TextBox("Email")%>
                    <%= Html.ValidationMessage("Email", "*")%>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label for="tbComment">
                        Comment:</label>
                </td>
                <td>
                    <%= Html.TextArea("Comment")%>
                    <%= Html.ValidationMessage("Comment", "*")%>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Enter symbols:
                </td>
                <td>
                    <%= Html.GenerateRecaptcha()%><br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <button class="ui-state-default ui-corner-all" type="submit">
                        Send</button>
                </td>
            </tr>
        </table>
    </fieldset>
    </form>
</asp:Content>
