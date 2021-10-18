using System;
using BusinessObjects.Table;
using System.Configuration;
using System.IO;

namespace CMS.FieldTemplates
{
    public partial class FileUploadField : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void SetControlValue(Column col)
        {
            lCurrent.Text = String.IsNullOrEmpty(col.Value.ToString()) ? "none" : col.Value.ToString();
        }

        public override object GetControlValue()
        {
            string value = lCurrent.Text;

            if (container.HasFile)
            {
                value = DateTime.Now.Ticks + "_" + container.FileName;

                var uploadPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var fileName = uploadPath + "\\" + value;
                container.SaveAs(fileName);

            }

            return value;
        }
    }
}