using System.Collections.Generic;
using QueryBuilders.Queries;
using BusinessObjects.Table;

namespace QueryBuilders.Builders
{
    /// <summary>
    /// Fluent Builder
    /// </summary>
    public abstract class QueryBuilder
    {
        protected Query _query;

        internal QueryBuilder(Query query)
        {
            _query = query;
        }

        public QueryBuilder ForTable(string table)
        {
            _query.Table = table;
            return this;
        }

        public QueryBuilder WithId(string id)
        {
            _query.Id = id;
            return this;
        }

        public abstract QueryBuilder FromColumns(List<Column> list);

        protected abstract void Finalize();

        public static implicit operator Query(QueryBuilder builder)
        {
            builder.Finalize();
            return builder._query;
        }
    }
}
