using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Table
{
    /// <summary>
    /// Foreign Key.
    /// </summary>
    public class ForeignKey
    {
        public string TableFrom_Name { get; set; }

        public string TableFrom_Column { get; set; }
        
        public string TableTo_Name { get; set; }

        public string TableTo_Column { get; set; }
    }
}
