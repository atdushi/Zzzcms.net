using System;
using Facade.Table;


namespace CMS
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowUserTableList();
        }

        private void ShowUserTableList()
        {
            var tableFacade = new TableFacade();
            Repeater1.DataSource = tableFacade.GetUserTableList();
            Repeater1.DataBind();
        }
    }
}
