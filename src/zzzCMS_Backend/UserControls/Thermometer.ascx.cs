using System;
using System.Configuration;
using System.Text;
using CMS.Routing;

namespace CMS.UserControls
{
    public partial class Thermometer : System.Web.UI.UserControl
    {
        protected StringBuilder _thermometer;
        protected string _delimiter = " -> ";

        protected void Page_Load(object sender, EventArgs e)
        {
            _thermometer = new StringBuilder();

            _thermometer.Append("<a href='/Default.aspx'>" + ConfigurationManager.AppSettings["CmsName"] + "</a>");

            if (this.Page is ITable)
            {
                _thermometer.Append(_delimiter + "<a href='/View/" + (this.Page as ITable).TableName + "'>" + (this.Page as ITable).TableName + "</a>");
            }
        }

        protected string ThermometerString
        {
            get
            {
                return _thermometer.ToString();
            }
        }
    }
}