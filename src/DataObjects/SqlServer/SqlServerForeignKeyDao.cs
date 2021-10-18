using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Table;
using System.Data;

namespace DataObjects.SqlServer
{
    class SqlServerForeignKeyDao : IForeignKeyDao
    {
        public List<ForeignKey> GetForeignKeyList(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("SELECT");
            sql.Append(" K_Table = FK.TABLE_NAME,");
            sql.Append(" FK_Column = CU.COLUMN_NAME,");
            sql.Append(" PK_Table = PK.TABLE_NAME,");
            sql.Append(" PK_Column = PT.COLUMN_NAME,");
            sql.Append(" Constraint_Name = C.CONSTRAINT_NAME");
            sql.Append(" FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C");
            sql.Append(" INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME");
            sql.Append(" INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME");
            sql.Append(" INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME");
            sql.Append(" INNER JOIN (");
            sql.Append(" SELECT i1.TABLE_NAME, i2.COLUMN_NAME");
            sql.Append(" FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1");
            sql.Append(" INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME");
            sql.Append(" WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'");
            sql.Append(" ) PT ON PT.TABLE_NAME = PK.TABLE_NAME");
            sql.Append(" WHERE FK.TABLE_NAME='");
            sql.Append(tableName);
            sql.Append("'");

            var dt = Db.GetDataTable(sql.ToString());

            var resList = new List<ForeignKey>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select new ForeignKey
                                      {
                                          TableFrom_Name = tableName,
                                          TableFrom_Column = row.Field<string>("FK_Column"),
                                          TableTo_Name = row.Field<string>("PK_Table"),
                                          TableTo_Column = row.Field<string>("PK_Column")
                                      };

                resList.AddRange(list);
            }

            return resList;
        }

        public List<string> GetForeignKeyColumnNameList(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("SELECT");
            sql.Append(" K_Table = FK.TABLE_NAME,");
            sql.Append(" FK_Column = CU.COLUMN_NAME,");
            sql.Append(" PK_Table = PK.TABLE_NAME,");
            sql.Append(" PK_Column = PT.COLUMN_NAME,");
            sql.Append(" Constraint_Name = C.CONSTRAINT_NAME");
            sql.Append(" FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C");
            sql.Append(" INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME");
            sql.Append(" INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME");
            sql.Append(" INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME");
            sql.Append(" INNER JOIN (");
            sql.Append(" SELECT i1.TABLE_NAME, i2.COLUMN_NAME");
            sql.Append(" FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1");
            sql.Append(" INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME");
            sql.Append(" WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'");
            sql.Append(" ) PT ON PT.TABLE_NAME = PK.TABLE_NAME");
            sql.Append(" WHERE FK.TABLE_NAME='");
            sql.Append(tableName);
            sql.Append("'");

            var dt = Db.GetDataTable(sql.ToString());

            var resList = new List<string>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select row.Field<string>("FK_Column");

                resList.AddRange(list);
            }

            return resList;
        }

        public ForeignKey GetForeignKey(string tableName, string columnName)
        {
            var fk = (from s in GetForeignKeyList(tableName)
                             where s.TableFrom_Column == columnName
                             select s).FirstOrDefault();
            return fk;
        }

        public bool IsForeignKey(Column col)
        {
            var fkList = GetForeignKeyColumnNameList(col.TableName);

            return fkList.Contains(col.Name);
        }
    }
}
