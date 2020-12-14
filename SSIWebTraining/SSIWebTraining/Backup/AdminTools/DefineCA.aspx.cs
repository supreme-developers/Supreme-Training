using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSIWebTraining.Objects.Models;
namespace SSIWebTraining.AdminTools
{
    public partial class DefineCA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SSIRentEntities context = new SSIRentEntities())
            {
                Jobroles.DataSource = context.EmployeeJobRoles.ToList().OrderBy(x => x.JobRole);
                Jobroles.DataBind();

                RadComboBoxJobResp.DataSource = context.EmployeeQualifications.ToList().OrderBy(x => x.Qualification);
                RadComboBoxJobTitles.DataSource = context.EmployeeJobTitles.ToList().OrderBy(x => x.JobTitle);
                RadComboBoxUOM.DataSource = context.SchedulingRecurrenceUOMs.ToList();
                RadComboBoxFUOM.DataSource = context.SchedulingRecurrenceUOMs.ToList();

                RadComboBoxJobTitles.DataBind();
                RadComboBoxJobResp.DataBind();
                RadComboBoxUOM.DataBind();
                RadComboBoxFUOM.DataBind();

            }
            using (SSITrainingEntities context = new SSITrainingEntities())
            {
                var allGroups = context.CompetencyGroups.OrderBy(i => i.GroupName);
                rptTabs.DataSource = allGroups.ToList();
                rptTabs.DataBind();
            }
        }
    }
}