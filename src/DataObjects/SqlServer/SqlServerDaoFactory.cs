namespace DataObjects.SqlServer
{
    public class SqlServerDaoFactory : DaoFactory
    {
        public override IColumnDao ColumnDao
        {
            get { return new SqlServerColumnDao(); }
        }

        public override IForeignKeyDao ForeignKeyDao
        {
            get { return new SqlServerForeignKeyDao(); }
        }

        public override IMany2ManyLinkDao Many2ManyLinkDao
        {
            get { return new SqlServerMany2ManyDao(); }
        }

        public override ITableDao TableDao
        {
            get { return new SqlServerTableDao(); }
        }
    }
}
