using System.Collections.Generic;
using QueryBuilders.Queries;
using BusinessObjects.Table;

namespace QueryBuilders.Builders
{
    public class UpdateQueryBuilder : QueryBuilder
    {
        internal UpdateQueryBuilder(Query query)
            : base(query)
        {
        }

        public override QueryBuilder FromColumns(List<Column> list)
        {
            foreach (Column updatedColumn in list)
            {
                if (updatedColumn.Name.ToLower() == "id")
                    continue;

                _query.QueryString += " " + updatedColumn.Name + " = {0}" + updatedColumn.Value + "{0},";

                if (updatedColumn.Type.Contains("char")
                    || updatedColumn.Type.Contains("text")
                    || updatedColumn.Type.Contains("date"))
                {
                    _query.QueryString = string.Format(_query.QueryString, "'");
                }
                else
                {
                    _query.QueryString = string.Format(_query.QueryString, "");
                }
            }

            return this;
        }

     
        protected override void Finalize()
        {
            if (_query.QueryString.EndsWith(","))
            {
                _query.QueryString = _query.QueryString.Substring(0, _query.QueryString.Length - 1);
            }
            _query.QueryString += " where id = " + _query.Id;

            _query.QueryString = "update " + _query.Table + " set " + _query.QueryString;
        }
    }
}
