using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Table;
using System.Data;
using DataObjects.Utilities;

namespace DataObjects.SqlServer
{
    class SqlServerMany2ManyDao : IMany2ManyLinkDao
    {
        public List<Many2ManyLink> GetMany2ManyLinkList(string tableName)
        {
            var sql = new StringBuilder();
            sql.Append("select * from ");
            sql.Append(SystemViewCollection.RelationsIDs);
            sql.Append(" where TableName1 = '");
            sql.Append(tableName);
            sql.Append("'");

            var dt = Db.GetDataTable(sql.ToString());

            var resList = new List<Many2ManyLink>();

            if (dt != null)
            {
                var list = from row in dt.AsEnumerable()
                           select new Many2ManyLink
                                      {
                                          TableName = tableName,
                                          LinkedTableName = row.Field<string>("TableName2"),
                                          LinkId = row.Field<int>("Id").ToString(),
                                          Direction = (row.Field<int>("Direction") == 0 ? Direction.Forward : Direction.Backward),
                                          UseWidth = false
                                      };

                resList.AddRange(list);
            }

            return resList;
        }

        public int CreateMany2ManyLink(string tableName1, string tableName2)
        {
            var sql = new StringBuilder();
            sql.Append("insert into ");
            sql.Append(SystemTableCollection.zzz_RelationsIDs);
            sql.Append("(TableName_l, TableName_r, UseWidth) values(");
            sql.Append("'");
            sql.Append(tableName1);
            sql.Append("', '");
            sql.Append(tableName2);
            sql.Append("', 0)");

            return Db.Insert(sql.ToString(), true);
        }

        public string GetMany2ManyFilter(Many2ManyLink mk, string itemId)
        {
            var sql = new StringBuilder();
            var filter = string.Empty;

            if (mk.Direction == Direction.Forward)
            {
                sql.Append("select linked_item_id from ");
                sql.Append(SystemViewCollection.Relations);
                sql.Append(" where link_id = ");
                sql.Append(mk.LinkId);
                sql.Append(" and item_id = ");
                sql.Append(itemId);
            }
            else
            {
                sql.Append("select item_id as linked_item_id from ");
                sql.Append(SystemViewCollection.Relations);
                sql.Append(" where link_id = ");
                sql.Append(mk.LinkId);
                sql.Append(" and linked_item_id = ");
                sql.Append(itemId);
            }

            var dt = Db.GetDataTable(sql.ToString());

            if (dt != null)
            {
                filter = dt.Rows.Cast<DataRow>().Aggregate(filter, (current, row) => current + (row["linked_item_id"].ToString() + ","));
            }

            if (filter.Length > 0)
            {
                filter = filter.Substring(0, filter.Length - 1);
            }

            return filter;
        }

        public DataTable GetLinkedTableData(Many2ManyLink mk, string itemId, string filter)
        {
            if (filter.Length == 0) return new DataTable();

            var sql = new StringBuilder();
            sql.Append("select * from ");
            sql.Append(mk.LinkedTableName);
            sql.Append((filter == string.Empty ? string.Empty : " where Id in (" + filter + ")"));

            var dt = Db.GetDataTable(sql.ToString());

            return dt;
        }

        public void AddRelation(Many2ManyRelation relation)
        {
            var sql = new StringBuilder();

            if (relation.Link.Direction == Direction.Forward)
            {
                sql.Append("insert into ");
                sql.Append(SystemTableCollection.zzz_Relations);
                sql.Append("(link_id, item_id, linked_item_id) values( ");
                sql.Append(relation.Link.LinkId);
                sql.Append(", ");
                sql.Append(relation.ItemId);
                sql.Append(", ");
                sql.Append(relation.LinkedItemId);
                sql.Append(")");
            }
            else
            {
                sql.Append("insert into ");
                sql.Append(SystemTableCollection.zzz_Relations);
                sql.Append("(link_id, item_id, linked_item_id) values( ");
                sql.Append(relation.Link.LinkId);
                sql.Append(", ");
                sql.Append(relation.LinkedItemId);
                sql.Append(", ");
                sql.Append(relation.ItemId);
                sql.Append(")");
            }
            Db.Insert(sql.ToString());
        }

        public void DeleteRelation(Many2ManyRelation relation)
        {
            var sql = new StringBuilder();

            if (relation.Link.Direction == Direction.Forward)
            {
                sql.Append("delete from ");
                sql.Append(SystemTableCollection.zzz_Relations);
                sql.Append(" where link_id = ");
                sql.Append(relation.Link.LinkId);
                sql.Append(" and item_id = ");
                sql.Append(relation.ItemId);
                sql.Append(" and linked_item_id = ");
                sql.Append(relation.LinkedItemId);
            }
            else
            {
                sql.Append("delete from ");
                sql.Append(SystemTableCollection.zzz_Relations);
                sql.Append(" where link_id = ");
                sql.Append(relation.Link.LinkId);
                sql.Append(" and item_id = ");
                sql.Append(relation.LinkedItemId);
                sql.Append(" and linked_item_id = ");
                sql.Append(relation.ItemId);
            }

            Db.Update(sql.ToString());
        }

        public bool HasMany2ManyLink(string tableName)
        {
            var mk = (from s in GetMany2ManyLinkList(tableName)
                      where s.TableName == tableName
                      select s).FirstOrDefault();

            return mk != null;
        }
    }
}
