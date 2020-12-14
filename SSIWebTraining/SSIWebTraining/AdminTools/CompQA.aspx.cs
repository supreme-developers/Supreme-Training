using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSIWebTraining.Objects.Models;
using Telerik.Web.UI;

namespace SSIWebTraining.AdminTools
{
    public partial class CompQA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SSITrainingEntities context = new SSITrainingEntities())
            {
                var allGroups = context.CompetencyGroups.OrderBy(i => i.GroupName);
                var allTypes = context.CompetencyTypes.OrderBy(i => i.CompetencyTypeName);

                rptTabs.DataSource = allGroups.ToList();

                //rptPages.DataSource = allGroups.ToList();
                RadComboBoxType.DataSource = allTypes.ToList();
                RadComboBoxEditType.DataSource = allTypes.ToList();
                RadComboBoxEditType.DataBind();
                RadComboBoxType.DataBind();
                rptTabs.DataBind();
                //rptPages.DataBind();
            }
        }
        protected void RadComboBoxGroups_ItemsRequested(object sender, Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs e)
        {
            using (SSITrainingEntities context = new SSITrainingEntities())
            {
                //var allGroups = context.CompetencyGroups.OrderBy(i => i.GroupName);
                //RadComboBoxGroups.DataSource = allGroups.ToList();
                //RadComboBoxGroups.DataBind();
            }
        }

        protected void RadComboBoxType_ItemsRequested(object sender, Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox RadComboBoxType = (RadComboBox)sender;
            using (SSITrainingEntities context = new SSITrainingEntities())
            {
                var allTypes = context.CompetencyTypes.OrderBy(i => i.CompetencyTypeName);
                RadComboBoxType.DataSource = allTypes.ToList();
                RadComboBoxType.DataBind();
            }
        }
    }
}