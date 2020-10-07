using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using SSIWebTraining.Objects.Models;
using SSIWebTraining.Controllers;

namespace SSIWebTraining
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }
        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            //I'm doing this so that I only need to redirect when the sign out button is clicked on the master page
            Session["Name"] = null;
            Session["USERID"] = null;
            Session["UserName"] = null;
            Session["IsAdmin"] = null;

        }

        private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
        {
            using (SSIRentEntities context = new SSIRentEntities())
            {
                var user = context.Database.SqlQuery<User>("exec sp_SYS_GetUserCredentials @UserName, @Password", 
                    new SqlParameter("UserName", UserName), new SqlParameter("Password", Password)).ToList();

                if (user.Count > 0)
                {
                    GlobalController globalController = new GlobalController();
                   

                    CheckBox cek = (CheckBox)Login2.FindControl("RememberMe");
                    Session["Name"] = user[0].Firstname + " " + user[0].LastName;
                    Session["USERID"] = user[0].UserID;
                    Session["UserName"] = UserName;

                    bool isAdmin = globalController.EmployeeIsAdmin(user[0].UserID, null);
                    Session["IsAdmin"] = isAdmin;

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    Login2.UserName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(120),
                    false, "ApplicationSpecific data for this user.",
                    FormsAuthentication.FormsCookiePath);
                    //encrypt ticket
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                    //if (cek.Checked)
                    //{
                    //    HttpCookie cookie = new HttpCookie("username");
                    //    cookie.Value = Login2.UserName;
                    //    //    cookie.Expires = DateTime.Now.AddDays(1);//cookie Expires
                    //    HttpContext.Current.Response.AppendCookie(cookie);
                    //}
                    return true;
                }
                else
                    return false;

            }
         
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MainMenu.aspx");
        }

        protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = SiteSpecificAuthenticationMethod(Login2.UserName, Login2.Password);

            // string url = HttpContext.Current.Request.Url.AbsolutePath;

            if (e.Authenticated && Session["OrigUrl"] != null)
            {
                Response.Redirect(Session["OrigUrl"].ToString());
            }
            else
            {
                if (e.Authenticated)
                    Response.Redirect("/AdminTools/EditCA.aspx");
                else
                {
                    Login2.FailureText = "The User Name and/or Password is not correct";
                    Login2.FailureAction = LoginFailureAction.RedirectToLoginPage;
                }
            }
        }
    }
}