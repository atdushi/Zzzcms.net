using System;
using System.Web.UI.WebControls;
using BusinessObjects.Table;

namespace CMS.FieldTemplates
{
    public partial class ForeignKeyField : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void SetControlValue(Column col)
        {
            var fk = FkFacade.GetForeignKey(col.TableName, col.Name);
            var dt = TableFacade.GetTableData(fk.TableTo_Name);

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                container.Items.Add(new ListItem(row["Title"].ToString(), row["Id"].ToString()));
            }

            container.SelectedIndex = container.Items.IndexOf(container.Items.FindByValue(col.Value.ToString()));
        }

        public override object GetControlValue()
        {
            return container.SelectedValue;
        }
    }
}