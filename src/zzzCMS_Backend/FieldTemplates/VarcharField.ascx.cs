using System;
using BusinessObjects.Table;

namespace CMS.FieldTemplates
{
    public partial class VarcharField : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void SetControlValue(Column col)
        {
            container.Text = col.Value.ToString();
            container.Enabled = (col.Name.ToLower() == "id" ? false : true);
        }

        public override object GetControlValue()
        {
            string text = container.Text.Replace("\"", "'");
            return String.IsNullOrEmpty(text) ? "null" : text;
        }
    }
}