using System;
using System.Data;
using System.Web.UI.WebControls;
using Facade.Table;
using CMS.Routing;

namespace CMS
{
    public partial class ViewTable : PageBase, ITableView
    {
        private static readonly TableFacade TableFacade = new TableFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTableData();
            }
        }

        private void LoadTableData()
        {
            GridView1.DataSource = TableFacade.GetTableData(TableName);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = TableFacade.GetTableData(TableName);
            string rowId = dt.Rows[GridView1.SelectedIndex]["Id"].ToString();

            RedirectToEditPage(rowId);
        }

        private void RedirectToEditPage(string rowId)
        {
            Response.Redirect("~/Edit/" + TableName + "/" + RowActions.Edit + "/" + rowId);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = TableFacade.GetTableData(TableName);
            string rowId = dt.Rows[e.RowIndex]["Id"].ToString();

            DeleteTableRow(rowId);
            LoadTableData();
        }

        private void DeleteTableRow(string rowId)
        {
            var table = new TableFacade();
            if (!table.DeleteRow(TableName, rowId))
            {
                lMessage.Text = "Can not delete the row.";
            }
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            RedirectToEditPage("0");
        }


        public string TableName
        {
            get;
            set;
        }

    }
}
