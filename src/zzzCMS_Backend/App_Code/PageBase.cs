using System;

namespace CMS
{
    public class PageBase : System.Web.UI.Page
    {
        private DateTime startTime = DateTime.Now;
        private TimeSpan renderTime;

        /// <summary>
        /// Sets and gets the page render starting time. 
        /// </summary>
        public DateTime StartTime
        {
            set { startTime = value; }
            get { return startTime; }
        }

        /// <summary>
        /// Gets page render time. This property is virtual therefore getting the 
        /// page performance is overridable by derived pages. 
        /// </summary>
        public virtual string PageRenderTime
        {
            get
            {
                renderTime = DateTime.Now - startTime;
                return renderTime.Seconds + "." + renderTime.Milliseconds + " seconds";
            }
        }
    }
}
