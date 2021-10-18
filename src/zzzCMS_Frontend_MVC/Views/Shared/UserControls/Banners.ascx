<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="System.Data" %>
<div class="rightheading">
    <h4>
        Banners</h4>
</div>
<div id="galleryblank">
    <% for (int i = 0; i < ((DataTable)ViewData["Banners"]).Rows.Count; i++)
       {%>
    <a href="<%= ((DataTable)ViewData["Banners"]).Rows[i]["Link"].ToString() %>">
        <img src="<%= ConfigurationManager.AppSettings["UploadPath"] + "/" %><%= ((DataTable)ViewData["Banners"]).Rows[i]["Picture"].ToString() %>"
            alt="<%= ((DataTable)ViewData["Banners"]).Rows[i]["Title"].ToString() %>" height="100"
            width="155" style="border: none" /></a>
    <% } %>
    
    <%-- <div class="rightheading">
        <h4>
            Creative story</h4>
    </div>
    <div class="righttxt">
        <span class="rightboldtxt">01. aliquet tempor nisi tellus </span>bibendum nunc.
        Sed venenatis scelerisque ipsum.</div>
    <div class="righttxt">
        <span class="rightboldtxt">02. Tempor nisi tellus </span>
        <br />
        Ndum nunc. Sed venenatis scelerisque ipsum.</div>
    <div class="righttxt">
        <span class="rightboldtxt">03. Kempor sisi vellus </span>
        <br />
        Qchdum nunc. Sed venenatis scelerisque ipsum.</div>
    <div class="righttxt">
        <span class="rightboldtxt">04. Aliquet tempor nisi tellus </span>bibendum nunc.
        Sed venenatis</div>
    <div class="viewbuttonbot">
        <a href="#" class="view">read more</a></div>--%>
</div>
