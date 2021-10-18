<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateField.ascx.cs" Inherits="CMS.FieldTemplates.DateField" %>

<script type="text/javascript">
    $(document).ready(function() {
        $(".datepicker").datepicker();
    });
</script>

<asp:TextBox ID="container" CssClass="datepicker" runat="server" Width="500"></asp:TextBox>
