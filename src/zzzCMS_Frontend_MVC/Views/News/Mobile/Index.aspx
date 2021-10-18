<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile/Site.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            $("#list").jqGrid({
                url: '../../News/GetNews',
                datatype: 'json',
                mType: 'GET',
                colNames: ['№', 'Anons', 'Date', 'Text'],
                colModel: [
                     { name: 'id', index: 'id', width: 55, resizable: true },
                     { name: 'title', index: 'title', width: 90, resizable: true },
                     { name: 'date', index: 'date', width: 70, resizable: true },
                     { name: 'text', index: 'text', width: 120, resizable: true}],
                pager: $('#pager'),
                rowNum: 10,
                rowList: [10, 20, 30],
                sortname: 'id',
                sortorder: 'desc',
                viewrecords: true,
                //multiselect: true,
                //multikey: "ctrlKey",
                imgpath: '/Content/sunny/images',
                caption: '<h1>News</h1>'
            });
        });
    </script>

    <!-- the grid definition in html is a table tag with class 'scroll' -->
    <table id="list" class="scroll" cellpadding="0" cellspacing="0">
    </table>
    <!-- pager definition. class scroll tels that we want to use the same theme as grid -->
    <div id="pager" class="scroll" style="text-align: center;">
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
   
    <script type="text/javascript" src="<%= this.ResolveClientUrl("~/Scripts/jquery-1.3.2.min.js") %>"></script>

    <script type="text/javascript" src="<%= this.ResolveClientUrl("~/Scripts/jqgrid-3.4.4/i18n/grid.locale-en.js") %>"></script>

    <script type="text/javascript" src="<%= this.ResolveClientUrl("~/Scripts/jqgrid-3.4.4/grid.base.js") %>"></script>

</asp:Content>
