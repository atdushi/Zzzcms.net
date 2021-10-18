<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="BusinessObjects" %>
<%@ Import Namespace="Controllers.Models" %>
<div id="leftheading">
    <h4>
        <table>
            <tr>
                <td>
                    Latest Events
                </td>
                <td>
                    <%= Html.ActionLinkWithImage("~/Content/images/feeds.png", "Feed")%>
                </td>
            </tr>
        </table>
    </h4>
</div>
<% foreach (News events in (IQueryable<News>)ViewData["Events"])
   {%>
<div class="lefttxtblank">
    <div class="lefticon">
        <%= events.Date.Day %></div>
    <div class="leftboldtxtblank">
        <div class="leftboldtxt">
            <%= events.Title %></div>
        <div class="lefttxt">
            <%= events.Date.ToShortDateString() %></div>
    </div>
    <div class="leftnormaltxt">
        <%= events.Text %></div>
    <%--    <div class="morebutton">
        <a href="#" class="more">read more... </a>
    </div>--%>
</div>
<% } %>
