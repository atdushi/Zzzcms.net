using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataObjects.Utilities;

namespace DataObjects.SQLite
{
    public class SqLiteTableDao : ITableDao
    {
        public List<string> GetUserTableList()
        {
            var sql = new StringBuilder();
            sql.Append("select * from sqlite_master where type = 'table' and tbl_name not like 'zzz%' and tbl_name != '" + SystemTableCollection.sqlite_sequence + "'");

            var dt = Db.GetDataTable(sql.ToString());

            var sl = new List<string>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select row.Field<string>("tbl_name");

                sl.AddRange(list);
            }

            return sl;
        }

        public List<string> GetSystemTableList()
        {
            var sql = new StringBuilder();
            sql.Append("select * from sqlite_master where type = 'table' and tbl_name like 'zzz%'");

            var dt = Db.GetDataTable(sql.ToString());

            var sl = new List<string>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select row.Field<string>("tbl_name");

                sl.AddRange(list);
            }

            return sl;
        }

        public DataTable GetTableData(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("select * from ");
            sql.Append(tableName);

            return Db.GetDataTable(sql.ToString());
        }

        public bool DeleteRow(string tableName, string rowId)
        {
            var sql = new StringBuilder();
            sql.Append("delete from ");
            sql.Append(tableName);
            sql.Append(" where Id = ");
            sql.Append(rowId);

            try
            {
                Db.Update(sql.ToString());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void AddFilePathColumn(string tableName, string columnName)
        {
            var sql = new StringBuilder();
            sql.Append("insert into ");
            sql.Append(SystemTableCollection.zzz_SiteFiles);
            sql.Append("(TableName, ColumnName) values('");
            sql.Append(tableName);
            sql.Append("', '");
            sql.Append(columnName);
            sql.Append("')");

            Db.Insert(sql.ToString());
        }

        public int GetMaxID(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("select max(Id) as maxId from ");
            sql.Append(tableName);

            var dt = Db.GetDataTable(sql.ToString());

            var maxId = -1;

            if (dt != null)
            {
                maxId = (from row in dt.AsEnumerable()
                           select row.Field<int>("maxId")).SingleOrDefault();
            }

            return maxId;
        }

        public void ExecuteUpdate(string sql)
        {
            Db.Update(sql);
        }

        public int ExecuteInsert(string sql, bool getId)
        {
            return Db.Insert(sql, getId);
        }
    }
}
