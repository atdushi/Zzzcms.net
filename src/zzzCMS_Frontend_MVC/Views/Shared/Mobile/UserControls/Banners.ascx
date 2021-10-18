<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="System.Data" %>
<h4>
    Banners</h4>
<% for (int i = 0; i < ((DataTable)ViewData["Banners"]).Rows.Count; i++)
   {%>
<a href="<%= ((DataTable)ViewData["Banners"]).Rows[i]["Link"].ToString() %>">
    <img src="<%= ConfigurationManager.AppSettings["UploadPath"] + "/" %><%= ((DataTable)ViewData["Banners"]).Rows[i]["Picture"].ToString() %>"
        alt="<%= ((DataTable)ViewData["Banners"]).Rows[i]["Title"].ToString() %>" height="100"
        width="155" style="border: none" /></a>
<% } %>