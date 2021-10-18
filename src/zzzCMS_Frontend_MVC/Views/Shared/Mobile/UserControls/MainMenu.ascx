<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="BusinessObjects" %>
<%@ Import Namespace="System.Data" %>

<h4>Menu</h4>
<ul>
    <% foreach (MenuAndPage map in (IQueryable<MenuAndPage>)ViewData["MainMenu"])
       {%>
    <li>
       <%= Html.ActionLink(map.Title, "Index", "Home", new { id = map.Id }, new { @class = "menu" })%>
    </li>
    <% } %>
</ul>
