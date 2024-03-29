﻿<%@ Page Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="ViewTable.aspx.cs"
    Inherits="CMS.ViewTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <%=Request.QueryString["t"] %></h2>
    <asp:Label ID="lMessage" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        AutoGenerateDeleteButton="True" OnRowDeleting="GridView1_RowDeleting" EmptyDataText="No data available."
        CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btAdd" runat="server" Text="Create" OnClick="btAdd_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
