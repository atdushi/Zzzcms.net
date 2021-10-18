using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessObjects.Table;
using DataObjects.Utilities;

namespace DataObjects.SqlServer
{
    class SqlServerColumnDao : IColumnDao
    {
        public List<Column> GetColumnList(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '");
            sql.Append(tableName);
            sql.Append("'");

            var dt = Db.GetDataTable(sql.ToString());

            var resList = new List<Column>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select new Column
                                      {
                                          TableName = tableName,
                                          Name = row.Field<string>("COLUMN_NAME"),
                                          Type = row.Field<string>("DATA_TYPE"),
                                          IsNullable = row.Field<string>("IS_NULLABLE") == "NO" ? false : true
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
                       select row[col.Name].ToString()).SingleOrDefault<string>();
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
