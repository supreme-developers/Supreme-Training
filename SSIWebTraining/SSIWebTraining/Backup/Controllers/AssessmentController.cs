using SSIWebTraining.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace SSIWebTraining.Controllers
{
    public class AssessmentController : Controller
    {
        // GET: Assessment
        public string GetManager_Employees()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            //var listOfStrings = new List<string>();
            //string[] arrayOfStrings = listOfStrings.ToArray();

            try
            {
                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetManagerEmployees(Convert.ToInt32(Session["UserID"])).ToArray();
                    var json = jsonSerialiser.Serialize(result);
                    return json;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetEmployeeCompetencies(int EmployeeID)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var listOfStrings = new List<string>();
            string[] arrayOfStrings = listOfStrings.ToArray();
            try
            {

                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetEmployeeCompetencies(EmployeeID).ToArray();


                    var json = jsonSerialiser.Serialize(result);
                    return json;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}