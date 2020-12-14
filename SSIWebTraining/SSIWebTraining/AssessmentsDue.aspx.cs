using SSIWebTraining.Objects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSIWebTraining
{
    public partial class AssessmentsDue : System.Web.UI.Page
    {
        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                LabelMessage.Text = Session["EmployeeID"].ToString();
            }
            //else
            //{
            //    Session["EmployeeID"] = "2931";
            //}
          
            //if (Session["LastSix"] == null)
            //    Response.Redirect("~/Login.aspx?");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] != null)
            {
                LabelMessage.Text = Session["EmployeeID"].ToString();
            }
            //else
            //{
            //    Session["EmployeeID"] = "2931";
            //    Session["LastSix"] = "22160";
            //}
            int employeeID = Convert.ToInt32(Session["EmployeeID"]);
            using (SSIRentEntities context = new SSIRentEntities())
            {
                EmployeeList.DataSource = context.Employees
                                            .Where(emp => emp.TerminationDate == null && 
                                                emp.EmployeeID != employeeID) 
                                            .OrderBy(emp => emp.EmployeeNumber)                                           
                                            .ToList();
                EmployeeList.DataBind();
            }
        }
    }
}