using BusinessObjects.Table;
using Facade.Table;

namespace CMS
{
    public abstract class UserControlBase : System.Web.UI.UserControl
    {
        protected static ForeignKeyFacade FkFacade = new ForeignKeyFacade();
        protected static TableFacade TableFacade = new TableFacade();
        protected static ColumnFacade ColumnFacade = new ColumnFacade();
        protected static Many2ManyLinkFacade M2MLinkFacade = new Many2ManyLinkFacade();

        public abstract void SetControlValue(Column col);
        public abstract object GetControlValue();
    }
}
