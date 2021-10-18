using System.Collections.Generic;
using QueryBuilders.Queries;
using BusinessObjects.Table;

namespace QueryBuilders.Builders
{
    public class InsertQueryBuilder : QueryBuilder
    {
        internal InsertQueryBuilder(Query query)
            : base(query)
        { }


        public override QueryBuilder FromColumns(List<Column> list)
        {
            foreach (var columnToInsert in list)
            {
                if (columnToInsert.Name.ToLower() == "id")
                    continue;

                if (columnToInsert.Value.ToString() == string.Empty &&
                     !(columnToInsert.Type.Contains("char")
                     || columnToInsert.Type.Contains("text")))
                {
                    columnToInsert.Value = "null";
                }

                ((InsertQuery) _query).ColumnString += columnToInsert.Name + ",";

                (_query as InsertQuery).ValueString += "{0}" + columnToInsert.Value + "{0},";

                if (columnToInsert.Type.Contains("char")
                    || columnToInsert.Type.Contains("text")
                    || columnToInsert.Type.Contains("date"))
                {
                    (_query as InsertQuery).ValueString = string.Format((_query as InsertQuery).ValueString, "'");
                }
                else
                {
                    (_query as InsertQuery).ValueString = string.Format((_query as InsertQuery).ValueString, "");
                }
            }

            return this;
        }

        protected override void Finalize()
        {
            if (((InsertQuery) _query).ColumnString.EndsWith(","))
            {
                (_query as InsertQuery).ColumnString = (_query as InsertQuery).ColumnString.Substring(0, (_query as InsertQuery).ColumnString.Length - 1);
            }

            if ((_query as InsertQuery).ValueString.EndsWith(","))
            {
                (_query as InsertQuery).ValueString = (_query as InsertQuery).ValueString.Substring(0, (_query as InsertQuery).ValueString.Length - 1);
            }

            _query.QueryString = ("insert into " + _query.Table + "(" + (_query as InsertQuery).ColumnString + ") values(" + (_query as InsertQuery).ValueString + ")");
        }
    }
}
