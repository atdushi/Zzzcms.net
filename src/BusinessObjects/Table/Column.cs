using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BusinessObjects.Table
{
    public class Column
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public object Value { get; set; }

        public string TableName { get; set; }

        public bool IsNullable { get; set; }
    }
}
