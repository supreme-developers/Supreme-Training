using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SSIWebTraining.Objects.Models;
namespace SSIWebTraining
{
    public partial class CreateCompetency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SSIRentEntities context = new SSIRentEntities())
            {
                Jobroles.DataSource = context.EmployeeJobRoles.ToList();
                Jobroles.DataBind();

                RadComboBoxJobResp.DataSource = context.EmployeeQualifications.ToList();
                RadComboBoxJobTitles.DataSource = context.EmployeeJobTitles.ToList();
                RadComboBoxJobTitles.DataBind();
                RadComboBoxJobResp.DataBind();
                
            }
        }
    }
}