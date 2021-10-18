using System;
using System.Web;
using System.IO;

namespace CMS.Setup
{
    public partial class Default : System.Web.UI.Page
    {
        private DateTime _startTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            _startTime = DateTime.UtcNow;
            RunSetup();
        }

        private void RunSetup()
        {
            WritePageHeader();

            String pathToScriptFolder = HttpContext.Current.Server.MapPath("~/Setup/mssql/");

            if (!Directory.Exists(pathToScriptFolder))
            {
                WritePageContent(pathToScriptFolder + " " + "Script Folder Not Found", false);
                return;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(pathToScriptFolder);

            FileInfo[] scriptFiles = directoryInfo.GetFiles("*.sql");

            Array.Sort(scriptFiles, CompareFileNames);

            if (scriptFiles.Length == 0)
            {
                WritePageContent("No Scripts Files Found" + " " + pathToScriptFolder, false);
                return;
            }

            foreach (FileInfo fi in scriptFiles)
            {
                WritePageContent("Running " + fi.Name);
                Facade.DatabaseHelper.DatabaseHelperRunScript(fi);
                WritePageContent("Ok");
            }

            WritePageContent("Scripts have been successfully executed!");
            WritePageFooter();
        }

        private void WritePageHeader()
        {
            if (HttpContext.Current == null) return;

            if (File.Exists(HttpContext.Current.Server.MapPath("~/Setup/SetupHeader.config")))
            {
                string sHtml = string.Empty;
                using (StreamReader oStreamReader = File.OpenText(System.Web.HttpContext.Current.Server.MapPath("~/Setup/SetupHeader.config")))
                {
                    sHtml = oStreamReader.ReadToEnd();
                }
                Response.Write(sHtml);
            }
            
            Response.Flush();
        }

        private void WritePageFooter()
        {
            Response.Write("</body>");
            Response.Write("</html>");
            Response.Flush();
        }

        public static int CompareFileNames(FileInfo f1, FileInfo f2)
        {
            return f1.FullName.CompareTo(f2.FullName);
        }

        private void WritePageContent(string message)
        {
            WritePageContent(message, false);
        }

        private void WritePageContent(string message, bool showTime)
        {

            if (showTime)
            {
                HttpContext.Current.Response.Write(
                    string.Format("{0} - {1}",
                    message,
                    DateTime.UtcNow.Subtract(_startTime)));
            }
            else
            {
                HttpContext.Current.Response.Write(message);
            }
            HttpContext.Current.Response.Write("<br/>");
            HttpContext.Current.Response.Flush();

        }
    }
}
