<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="BusinessObjects" %>
<div id="footerblank">
    <div id="footer">
        <div id="footerbox">
            <div class="footerheading">
                <h4>
                    Tempus</h4>
            </div>
            <div class="footertxt">
                Donec posuere bibendum erat. commodo consectetuer tellus. Ut ut tellus eget</div>
            <div class="footerbutton">
                <a href="#" class="button">read more</a></div>
        </div>
        <div id="footermid">
            <div class="footerheading">
                <h4>
                    Neque</h4>
            </div>
            <div class="footertxt">
                Neque nisl porttitor dolor, ut posuere nibh lectus vel pede. Nam non elit.</div>
            <div class="footerbutton">
                <a href="#" class="button">read more</a></div>
        </div>
        <div id="footerlast">
            <div class="footerheading">
                <h4>
                    Curabitur</h4>
            </div>
            <div class="footertxt">
                Eque nisl porttitor dolor, ut posuere nibh lectus vel pede. Nam non elit.
            </div>
            <div class="footerbutton">
                <a href="#" class="button">read more</a></div>
        </div>
        <div id="footerlinks">
            <% foreach (MenuAndPage map in (IQueryable<MenuAndPage>)ViewData["MainMenu"])
               {%>
            <%= Html.ActionLink(map.Title + " | ", "Index", "Home", new { id = map.Id }, new { @class = "footerlinks" })%>
            <% } %>
        </div>
        <div id="copyrights">
            © Copyright 2010 ZZZ CMS. All Rights Reserved.</div>
        <div id="designedby">
            Designed by <a href="http://www.templateworld.com" target="_blank" class="designedby">
                TemplateWorld</a> and brought to you by <a href="http://www.smashingmagazine.com"
                    target="_blank" class="designedby">SmashingMagazine</a></div>
        <div id="validation">
            <a href="http://validator.w3.org/check?uri=referer" class="xhtml">xhtml</a><a href="http://jigsaw.w3.org/css-validator/check/referer"
                class="css">css</a></div>
    </div>
</div>
