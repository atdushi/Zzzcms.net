using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Table;
using System.Data;
using DataObjects.Utilities;

namespace DataObjects.SQLite
{
    public class SqLiteColumnDao : IColumnDao
    {
        public List<Column> GetColumnList(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("PRAGMA table_info(");
            sql.Append(tableName);
            sql.Append(")");

            var dt = Db.GetDataTable(sql.ToString());

            var resList = new List<Column>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select new Column
                                      {
                                          TableName = tableName,
                                          Name = row.Field<string>("name"),
                                          Type = row.Field<string>("type"),
                                          IsNullable = row.Field<string>("notnull") == "1" ? false : true
                                      };

                resList.AddRange(list);
            }

            return resList;
        }

        public List<string> GetFilePathColumnNameList(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("select * from ");
            sql.Append(SystemTableCollection.zzz_SiteFiles);
            sql.Append(" where TableName = '");
            sql.Append(tableName);
            sql.Append("'");

            var dt = Db.GetDataTable(sql.ToString());

            var resList = new List<string>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select row.Field<string>("ColumnName");

                resList.AddRange(list);
            }

            return resList;
        }

        public object GetCellValue(Column col, string rowId)
        {
            var sql = new StringBuilder();
            sql.Append("select * from ");
            sql.Append(col.TableName);
            sql.Append(" where Id = ");
            sql.Append(rowId);

            var dt = Db.GetDataTable(sql.ToString());

            object res = string.Empty;

            if (dt != null)
            {
                res = (from row in dt.AsEnumerable()
                       select row.Field<string>(col.Name)).SingleOrDefault<string>();
            }

            return res;
        }

        public bool IsFilePath(Column col)
        {
            var fileColumnList = GetFilePathColumnNameList(col.TableName);

            return fileColumnList.Contains(col.Name);
        }

        public void SaveImage(Column col, byte[] image)
        {
            throw new NotImplementedException();
        }
    }
}
