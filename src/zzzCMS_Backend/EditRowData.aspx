<%@ Page Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="EditRowData.aspx.cs"
    Inherits="CMS.EditTable" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pControls" runat="server">
    </asp:Panel>
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btCancel" runat="server" Text="Cancel" OnClick="btCancel_Click"/>
            </td>
            <td>
                <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
