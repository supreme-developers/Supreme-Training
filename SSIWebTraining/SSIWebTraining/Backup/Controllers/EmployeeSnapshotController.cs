using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SSIWebTraining.Objects.Models;
namespace SSIWebTraining.Controllers
{
    public class EmployeeSnapshotController : Controller
    {
        // GET: EmployeeSnapshot
        public string GetSnapshotEmployees()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            using (var db = new SSITrainingEntities())
            {
                var snapshotEmployees = db.sp_CACompetency_GetSnapshotEmployees().ToList();

                var json = jsonSerialiser.Serialize(snapshotEmployees);
                return json;
            }
        }

        public string GetAllEmployeeCompetencies(int EmployeeID)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            try {
                using (var db = new SSITrainingEntities())
                {
                    var snapshotEmployees = db.sp_CACompetency_GetAllEmployeeCompetencies(EmployeeID).ToList();

                    var json = jsonSerialiser.Serialize(snapshotEmployees);
                    return json;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void AddToSnapshot(int EmployeeID,int CompDefHeaderID)
        {
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    context.sp_CACompetency_AddCompetency_toEmployeeSnapshot(EmployeeID, CompDefHeaderID, Convert.ToInt32(Session["UserID"]));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        
    }
        public void RemovefromSnapshot(int EmployeeID, int CompDefHeaderID)
        {
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    context.sp_CACompetency_DeleteCompetency_fromEmployeeSnapshot(EmployeeID, CompDefHeaderID, Convert.ToInt32(Session["UserID"]));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public string GetCompetencyDefinitions(int EmployeeID)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var listOfStrings = new List<string>();
            string[] arrayOfStrings = listOfStrings.ToArray();
            try
            {

                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetUnAssigned_CompetencyDefinitions(EmployeeID).ToList();


                    var json = jsonSerialiser.Serialize(result);
                    return json;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public string GetAssessorAssessments()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var listOfStrings = new List<string>();
            string[] arrayOfStrings = listOfStrings.ToArray();
            try
            {

                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetAssessor_Assessments(Convert.ToInt32(Session["EmployeeID"])).ToList();


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