<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CMS.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Administration</h2>
    <table>
        <tr>
            <td>
                <a href="CreateUser.aspx">Create new user</a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="ChangePassword.aspx">Change my password</a>
            </td>
        </tr>
    </table>
    <h2>
        Tables</h2>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%-- <a href="ViewTable.aspx?table=<%# Container.DataItem %>">
                        <%# Container.DataItem %></a>--%>
                    <a href="View/<%# Container.DataItem %>">
                        <%# Container.DataItem %></a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
