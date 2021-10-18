using System;
using System.Linq;
using System.Web.Mvc;
using BusinessObjects;
using Controllers.Models;

namespace Controllers.Controllers
{
    public class NewsController : BaseController
    {
        readonly ModelEntities _modelEntities;

        public NewsController()
        {
            _modelEntities = new ModelEntities();
        }

        [FillMasterPageViewData]
        public ActionResult Index()
        {
            IQueryable<BusinessObjects.News> news = _modelEntities.News.Select(n => n);

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sidx">Sort field</param>
        /// <param name="sord">Asc/desc</param>
        /// <param name="page">Page num</param>
        /// <param name="rows">Rows per page count</param>
        /// <returns></returns>
        public ActionResult GetNews(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            IQueryable<BusinessObjects.News> totalNews = _modelEntities.News.Select(n => n);
            var totalPages = (int)Math.Ceiling(totalNews.Count<BusinessObjects.News>() / (float)pageSize);
                        
            IQueryable<BusinessObjects.News> news = _modelEntities.News
                .Select(n => n)
                .OrderBy(n => n.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);

            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            var _rows = new object[news.Count<BusinessObjects.News>()];

            int i = 0;
            foreach (BusinessObjects.News piece in news)
            {
                _rows[i] = new { id = piece.Id, cell = new[] { piece.Id.ToString(), piece.Title, piece.Date.ToShortDateString(), piece.Text } };
                i++;
            }

            result.Data = new
            {
                total = totalPages,
                page,
                records = news.Count<BusinessObjects.News>(),
                rows = _rows
            };

            return result;
        }

    }
}
