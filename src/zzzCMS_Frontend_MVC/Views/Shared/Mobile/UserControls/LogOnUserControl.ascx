﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (HttpContext.Current.User.Identity.IsAuthenticated)
    {
        using (Html.BeginForm("LogOff", "Home"))
        {
%>
<h4>
    Welcome<b>
        <%= Html.Encode(Page.User.Identity.Name) %></b>!</h4>
<button class="ui-state-default ui-corner-all" type="submit">
    log off</button>
<%
    }
    }
    else
    {
        using (Html.BeginForm("LogOn", "Home"))
        {
%>
<h4>
    User Login</h4>
<table>
    <tr>
        <td>
            User Name:
        </td>
        <td>
            <label>
                <%=Html.TextBox("UserName")%>
            </label>
        </td>
    </tr>
    <tr>
        <td>
            Password:
        </td>
        <td>
            <label>
                <%=Html.Password("Password")%>
            </label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <button class="ui-state-default ui-corner-all" type="submit">
                login</button>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            Not yet a Member? <a href="#" class="register">Register Now</a>
        </td>
    </tr>
</table>
<%  }
    }
%>
