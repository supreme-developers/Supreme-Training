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
         
            if (Request.QueryString["LastSix"] != null)
            {
                Session["LastSix"] = Request.QueryString["LastSix"]; //means this came from a mobile device login
                Response.Redirect(Request.Url.AbsolutePath); //need to remove the lastsix Querystring now that the session is set
            }
           
            if (Session["LastSix"] != null)
            {
                //means this is from the Mobile Device and bars need to be hid.
               
              //  ScriptManager.RegisterStartupScript(this, this.GetType(), "closeScript", "hideTopSideBars()", true);
                if (Session["EmployeeID"] == null) 
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
                if (Session["USERID"] == null )
                {
                    Session["OrigUrl"] = Request.Url.AbsoluteUri.ToString();
                    Response.Redirect("~/Login.aspx?");
                }
                
            }
            if (Convert.ToBoolean(Session["IsAdmin"]) != false)
            {
                adminTools.Visible = true;
                mgrTools.Visible = false;
            }
            else
            {
                mgrTools.Visible = true;
                adminTools.Visible = false;
            }
            //LabelUser.Text = Session["Name"].ToString();
            User2.Text = LabelUser.Text;


        }
       

    }
}