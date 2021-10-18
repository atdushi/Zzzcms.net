<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="BusinessObjects" %>
<div id="leftnavheading">
    <h4>
        More links</h4>
</div>
<div id="leftnav">
    <ul>
        <% foreach (MenuAndPage map in (IOrderedEnumerable<MenuAndPage>)ViewData["SubMenu"])
           {%>
        <li>
            <%= Html.ActionLink(map.Title, "Index", "Home", new { id = map.Id }, new { @class = "leftnav" })%>
        </li>
        <% } %>
    </ul>
</div>
