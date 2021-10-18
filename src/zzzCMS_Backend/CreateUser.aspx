<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="CMS.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
    LoginCreatedUser="False" CancelDestinationPageUrl="~/Default.aspx" 
        ContinueDestinationPageUrl="~/Default.aspx">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
