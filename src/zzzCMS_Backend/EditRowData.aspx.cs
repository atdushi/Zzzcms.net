using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using BusinessObjects.Table;
using Facade.Table;
using CMS.FieldTemplates;
using CMS.Routing;
using QueryBuilders.Queries;

namespace CMS
{
    public partial class EditTable : PageBase, ITableEdit
    {
        private static readonly TableFacade TableFacade = new TableFacade();
        private static readonly ForeignKeyFacade FkFacade = new ForeignKeyFacade();
        private static readonly ColumnFacade ColFacade = new ColumnFacade();
        private static readonly Many2ManyLinkFacade M2MLinkFacade = new Many2ManyLinkFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateControls();
        }

        #region Controls
        private void CreateControls()
        {
            pControls.Controls.Add(new LiteralControl(TableHelper.TableOpen));

            // create controls
            foreach (Column col in ColFacade.GetColumnList(TableName))
            {
                col.Value = ColFacade.GetCellValue(col, Id);

                if (String.Equals(Action, RowActions.Add.ToString())
                    && String.Equals(col.Name.ToLower(), "id"))
                {
                    col.Value = "Has to be autoincrement!";
                }

                pControls.Controls.Add(new LiteralControl(TableHelper.RowOpen));
                pControls.Controls.Add(new LiteralControl(TableHelper.DataOpen));
                Label lbl = new Label();
                lbl.Text = col.Name + ": ";
                pControls.Controls.Add(lbl);
                pControls.Controls.Add(new LiteralControl(TableHelper.DataClose));
                pControls.Controls.Add(new LiteralControl(TableHelper.DataOpen));
                Control c = CreateControl(col);
                pControls.Controls.Add(c);
                pControls.Controls.Add(new LiteralControl(TableHelper.DataClose));
                pControls.Controls.Add(new LiteralControl(TableHelper.RowClose));
            }

            // create many to many controls
            foreach (Many2ManyLink mk in M2MLinkFacade.GetMany2ManyLinkList(TableName))
            {
                pControls.Controls.Add(new LiteralControl(TableHelper.RowOpen));
                pControls.Controls.Add(new LiteralControl(TableHelper.DataOpen));
                Label lbl = new Label();
                lbl.Text = mk.LinkedTableName + ": ";
                pControls.Controls.Add(lbl);
                pControls.Controls.Add(new LiteralControl(TableHelper.DataClose));
                pControls.Controls.Add(new LiteralControl(TableHelper.DataOpen));
                Control c = CreateMany2ManyControl(mk, Id);
                pControls.Controls.Add(c);
                pControls.Controls.Add(new LiteralControl(TableHelper.DataClose));
                pControls.Controls.Add(new LiteralControl(TableHelper.RowClose));
            }
            pControls.Controls.Add(new LiteralControl(TableHelper.TableClose));
        }

        private Control CreateControl(Column col)
        {
            // TextBox by default
            Control c = LoadControl(FieldTemplatePath.VarcharField);

            // Date
            if (col.Type.Contains("date"))
            {
                c = LoadControl(FieldTemplatePath.DateField);
            }

            // CheckBox
            if (col.Type == "bit")
            {
                c = LoadControl(FieldTemplatePath.BitField);
            }

            // RichTextBox
            if (col.Type.Contains("text"))
            {
                c = LoadControl(FieldTemplatePath.TextField);
            }

            // FileUpload
            if (ColFacade.IsFilePath(col))
            {
                c = LoadControl(FieldTemplatePath.FileUploadField);
            }

            // Foreign key
            if (FkFacade.IsForeignKey(col))
            {
                c = LoadControl(FieldTemplatePath.ForeignKeyField);
            }

            ((UserControlBase) c).SetControlValue(col);
            c.ID = col.Name;
            return c;
        }

        private Control CreateMany2ManyControl(Many2ManyLink mk, string itemId)
        {
            Many2ManyField c = (Many2ManyField)LoadControl(FieldTemplatePath.Many2ManyField);
            c.SetMany2ManyControlValue(mk, itemId);
            c.ID = mk.LinkedTableName;
            return c;
        }
        #endregion

        protected void btCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/" + TableName);
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            // Update regular and FileUpload fields
            List<Column> colList = ColFacade.GetColumnList(TableName);

            foreach (Column col in colList)
            {
                Control c = pControls.FindControl(col.Name);
                col.Value = ((UserControlBase)c).GetControlValue();
            }

            Query query = null;

            if (String.Equals(Action, RowActions.Edit.ToString()))
            {
                query = UpdateQuery.Create().ForTable(TableName).WithId(Id).FromColumns(colList);
                TableFacade.ExecuteUpdate(query.QueryString);
            }
            if (String.Equals(Action, RowActions.Add.ToString()))
            {
                query = InsertQuery.Create().ForTable(TableName).FromColumns(colList);
                query.Id = TableFacade.ExecuteInsert(query.QueryString, true).ToString();
            }

            // Update Many2Many fields
            foreach (Many2ManyLink mk in M2MLinkFacade.GetMany2ManyLinkList(TableName))
            {
                Many2ManyField mmf = (Many2ManyField)pControls.FindControl(mk.LinkedTableName);
                mmf.GetMany2ManyControlValue(mk, int.Parse(query.Id.ToString()));
            }
        }

        public string TableName { get; set; }

        public string Action { get; set; }

        public string Id { get; set; }

    }
}
