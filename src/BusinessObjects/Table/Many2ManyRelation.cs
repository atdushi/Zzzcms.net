using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Table
{
    public class Many2ManyRelation
    {
        public Many2ManyLink Link { get; set; }

        public int ItemId { get; set; }

        public int LinkedItemId { get; set; }
    }
}
