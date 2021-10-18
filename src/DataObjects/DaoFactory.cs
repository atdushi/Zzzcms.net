namespace DataObjects
{
    /// <summary>
    /// Abstract factory class that creates data access objects.
    /// </summary>
    public abstract class DaoFactory
    {
        /// <summary>
        /// Gets a column data access object.
        /// </summary>
        public abstract IColumnDao ColumnDao { get; }

        /// <summary>
        /// Gets a foreign key data access object.
        /// </summary>
        public abstract IForeignKeyDao ForeignKeyDao { get; }

        /// <summary>
        /// Gets a many to many data access object.
        /// </summary>
        public abstract IMany2ManyLinkDao Many2ManyLinkDao { get; }

        /// <summary>
        /// Gets a table data access object.
        /// </summary>
        public abstract ITableDao TableDao { get; }
    }
}
