namespace DataObjects.SQLite
{
    public class SqLiteDaoFactory : DaoFactory
    {
        public override IColumnDao ColumnDao
        {
            get { return new SqLiteColumnDao(); }
        }

        public override IForeignKeyDao ForeignKeyDao
        {
            get { return new SqLiteForeignKeyDao(); }
        }

        public override IMany2ManyLinkDao Many2ManyLinkDao
        {
            get { return new SqLiteMany2ManyDao(); }
        }

        public override ITableDao TableDao
        {
            get { return new SqLiteTableDao(); }
        }
    }
}
