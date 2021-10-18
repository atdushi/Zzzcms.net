using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Table;
using System.Data;

namespace DataObjects.SQLite
{
    public class SqLiteForeignKeyDao : IForeignKeyDao
    {
        public List<ForeignKey> GetForeignKeyList(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("PRAGMA foreign_key_list(");
            sql.Append(tableName);
            sql.Append(")");

            var dt = Db.GetDataTable(sql.ToString());

            var resList = new List<ForeignKey>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select new ForeignKey
                                      {
                                          TableFrom_Name = tableName,
                                          TableFrom_Column = row.Field<string>("from"),
                                          TableTo_Name = row.Field<string>("table"),
                                          TableTo_Column = row.Field<string>("to")
                                      };

                resList.AddRange(list);
            }

            return resList;
        }

        public List<string> GetForeignKeyColumnNameList(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("PRAGMA foreign_key_list(");
            sql.Append(tableName);
            sql.Append(")");

            var dt = Db.GetDataTable(sql.ToString());

            var resList = new List<string>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select row.Field<string>("from");

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
