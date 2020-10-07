using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSIWebTraining.Objects.Models;

namespace SSIWebTraining.Controllers
{
    public class GlobalController : Controller
    {
        // GET: Global
       public MobileUser GetMobileUser (string LastSix)
        {
            MobileUser mobileUser = new MobileUser();
            try
            {
                using (var db = new SSITrainingEntities())
                {
                    var query = db.sp_sys_GetMobileLogin(LastSix).Single();

                    mobileUser.Name = query.Name;
                    mobileUser.EmployeeID = query.EmployeeID;
                    mobileUser.EmployeeNumber = query.EmployeeNumber;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return mobileUser;

           
        }
        public Boolean EmployeeIsAdmin(int? UserID, int? EmployeeID )
        {
            Boolean isAdmin = false;
            try
            {
                using (var db = new SSITrainingEntities())
                {
                    var query = db.sp_CACompetency_EmployeeIsAdmin(UserID, EmployeeID).Single();
                    isAdmin = Convert.ToBoolean(query.isAdmin);
                  
                }
            }
            catch (Exception ex)
            {

            }
            return isAdmin;
        }
    }
}