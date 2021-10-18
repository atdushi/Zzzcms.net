using System.Web;

namespace CMS.Routing
{
    interface ITableEdit : IHttpHandler, ITable
    {
        string Action { get; set; }
        string Id { get; set; }
    }
}
