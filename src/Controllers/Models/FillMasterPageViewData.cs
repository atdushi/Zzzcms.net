using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessObjects;
using BusinessObjects.Table;
using System.Data.Objects.DataClasses;
using Facade.Table;

namespace Controllers.Models
{
    public class FillMasterPageViewData : ActionFilterAttribute
    {
        private ModelEntities modelEntities = new ModelEntities();

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session == null) return;

            var curPageId = String.IsNullOrEmpty(filterContext.HttpContext.Session["PageId"].ToString())
                                ? 1 : int.Parse(filterContext.HttpContext.Session["PageId"].ToString());

            var result = filterContext.Result as ViewResult;

            if (result == null) return;

            FillMainMenu(result);

            FillEvents(result);

            FillBanners(result, curPageId);

            FillSubMenu(result, curPageId);

            base.OnActionExecuted(filterContext);
        }

        private void FillSubMenu(ViewResult result, int curPageId)
        {
            IQueryable<MenuAndPage> pages = modelEntities.MenuAndPages.Select(m => m).Where(m => m.Id == curPageId);

            foreach (MenuAndPage page in pages)
            {
                EntityCollection<MenuAndPage> subPages = page.SubPages;
                IOrderedEnumerable<MenuAndPage> subPagesQuery = subPages.Select(m => m).OrderBy(m => m.MenuSortOrder);

                result.ViewData["SubMenu"] = subPagesQuery;
                result.ViewData["Message"] = page.Text;
                result.ViewData["Title"] = page.Title;

                break;
            }
        }

        private void FillEvents(ViewResult result)
        {
            IQueryable<News> events = modelEntities.News.Where(n => n.NewsCategory.Id == 2);
            result.ViewData["Events"] = events;
        }

        private void FillMainMenu(ViewResult result)
        {
            IQueryable<MenuAndPage> allPages = modelEntities.MenuAndPages.Select(m => m).OrderBy(m => m.MenuSortOrder);
            result.ViewData["MainMenu"] = allPages;
        }

        private void FillBanners(ViewResult result, int curPageId)
        {
            Many2ManyLinkFacade m2MFacade = new Many2ManyLinkFacade();
            List<Many2ManyLink> m2mLinkList = m2MFacade.GetMany2ManyLinkList("MenuAndPages");

            foreach (Many2ManyLink m2ml in m2mLinkList)
            {
                if (m2ml.LinkedTableName == "Banners")
                {
                    result.ViewData["Banners"] = m2MFacade.GetLinkedTableData(m2ml, curPageId.ToString());
                }
            }
        }
    }
}
