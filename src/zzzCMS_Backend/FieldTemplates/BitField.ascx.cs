using System;
using BusinessObjects.Table;

namespace CMS.FieldTemplates
{
    public partial class BitField : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void SetControlValue(Column col)
        {
            if (col.Value.ToString().Length > 2)
            {
                container.Checked = col.Value.ToString() == "True" ? true : false;
            }
            else
            {
                container.Checked = col.Value.ToString() == "1" ? true : false;
            }
        }

        public override object GetControlValue()
        {
            return container.Checked ? 1 : 0;
        }
    }
}