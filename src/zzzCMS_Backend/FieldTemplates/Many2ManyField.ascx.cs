using System;
using System.Web.UI.WebControls;
using BusinessObjects.Table;
using System.Data;

namespace CMS.FieldTemplates
{
    public partial class Many2ManyField : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void SetControlValue(Column col)
        {
            throw new NotImplementedException();
        }

        public void SetMany2ManyControlValue(Many2ManyLink mk, string itemId)
        {
            // retrieve
            var dt = TableFacade.GetTableData(mk.LinkedTableName);

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                container.Items.Add(new ListItem(row["Title"].ToString(), row["Id"].ToString()));
            }

            // mark
            dt = M2MLinkFacade.GetLinkedTableData(mk, itemId);

            for (var j = 0; j < container.Items.Count; j++)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var row = dt.Rows[i];
                    if (row["Title"].ToString() == container.Items[j].Text
                        && row["Id"].ToString() == container.Items[j].Value)
                    {
                        container.Items[j].Selected = true;
                    }
                }
            }

        }

        public override object GetControlValue()
        {
            throw new NotImplementedException();
        }

        public void GetMany2ManyControlValue(Many2ManyLink mk, int id)
        {
            foreach (ListItem item in container.Items)
            {
                var m2mRelation = new Many2ManyRelation
                                      {
                                          Link = mk, 
                                          ItemId = id, 
                                          LinkedItemId = int.Parse(item.Value)
                                      };

                if (item.Selected)
                {
                    M2MLinkFacade.AddRelation(m2mRelation);
                }
                else
                {
                    M2MLinkFacade.DeleteRelation(m2mRelation);
                }
            }
        }
    }
}