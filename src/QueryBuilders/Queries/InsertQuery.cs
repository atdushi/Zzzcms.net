using QueryBuilders.Builders;

namespace QueryBuilders.Queries
{
    public class InsertQuery : Query
    {
        public string ColumnString = string.Empty;
        public string ValueString = string.Empty;

        public static InsertQueryBuilder Create()
        {
            return new InsertQueryBuilder(new InsertQuery());
        }

    }
}
