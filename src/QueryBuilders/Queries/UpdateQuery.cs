using QueryBuilders.Builders;

namespace QueryBuilders.Queries
{
    public class UpdateQuery : Query
    {
        public static UpdateQueryBuilder Create()
        {
            return new UpdateQueryBuilder(new UpdateQuery());
        }
    }
}
