using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSIWebTraining.Objects.Models;
using SSIWebTraining.Controllers;

namespace SSIWebTraining
{
    public partial class Training : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastSix"] = "578320";
            if (Session["LastSix"] != null)
            {
                if (Session["EmployeeID"] != null) //means already logged in and doesn't need to hit the following statements
                {
                    GlobalController globalController = new GlobalController();
                    MobileUser mobileUser = globalController.GetMobileUser(Session["LastSix"].ToString());

                    Session["Name"] = mobileUser.Name;
                    Session["EmployeeID"] = mobileUser.EmployeeID;
                    Session["EmployeeNumber"] = mobileUser.EmployeeNumber;
                }
            }
            else
            {
                if (Session["USERID"] == null)
                {
                    Session["OrigUrl"] = Request.Url.ToString();
                    Response.Redirect("~/Login.aspx?");
                }
            }
            LabelUser.Text = Session["Name"].ToString();
            User2.Text = LabelUser.Text;


        }
    }
}