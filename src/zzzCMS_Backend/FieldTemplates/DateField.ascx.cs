using System;
using BusinessObjects.Table;

namespace CMS.FieldTemplates
{
    public partial class DateField : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void SetControlValue(Column col)
        {
            try
            {
                container.Text = DateTime.Parse(col.Value.ToString()).ToShortDateString();
            }
            catch
            {
                container.Text = DateTime.Now.ToShortDateString();
            }
        }

        public override object GetControlValue()
        {
            const string format = "yyyy-MM-dd";
            return DateTime.Parse(container.Text).ToString(format);
        }
    }
}