using System;
using BusinessObjects.Table;

namespace CMS.FieldTemplates
{
    public partial class TextField : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void SetControlValue(Column col)
        {
            container.Text = col.Value.ToString();
        }

        public override object GetControlValue()
        {
            return container.Text.Replace("\"", "'");
        }
    }
}