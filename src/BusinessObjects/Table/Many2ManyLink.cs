using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Table
{
    public enum Direction
    {
        Forward, // Table1 -> Table2
        Backward // Table2 -> Table1
    }

    /// <summary>
    /// TableFrom_Column and TableTo_Column are always 'Id'.
    /// </summary>
    public class Many2ManyLink
    {
        public string LinkId { get; set; }

        public string TableName { get; set; }

        public string LinkedTableName { get; set; }

        public Direction Direction { get; set; }

        /// <summary>
        /// For future releases.
        /// </summary>
        public bool UseWidth { get; set; }
    }
}
