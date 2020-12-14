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
        public int? CreateEmployeeAssessment(int compDefHeaderID, int EmployeeID)
        {
            //int? assessmentID = 0;
            var assessmentID = (int?)null;
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    assessmentID =  context.sp_CACompetency_CreateEmployeeAssessment(compDefHeaderID, EmployeeID, Convert.ToInt32(Session["EmployeeID"])).FirstOrDefault();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return assessmentID;

        }
        public string GetEmployeeAssessment (int CompetencyAssessmentID)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var listOfStrings = new List<string>();
            string[] arrayOfStrings = listOfStrings.ToArray();
            try
            {

                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetEmployeeAssessment(CompetencyAssessmentID).ToArray();


                    var json = jsonSerialiser.Serialize(result);
                    return json;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public string updateEmpTaskCompetency(int CompetencyAssessment_DetailID, Boolean IsCompetent, string Note)
        {
            // var result = (int?)null;
            string result = "";
            try
            {
                // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                    context.sp_CACompetency_UpdateEmpTaskCompetency(CompetencyAssessment_DetailID, IsCompetent, Convert.ToInt32(Session["EmployeeID"]), Note);
                    
                }
            }
            catch (Exception ex)
            {
                result = "Competency Update Failed";
                Console.WriteLine(result);
            }
            return result;
        }

        public string FinalizeCompetency(int CompetencyAssessmentID, int LastSix)
        {
           
            var jsonSerialiser = new JavaScriptSerializer();
            using (var context = new SSITrainingEntities())
            {
               
                    var result = context.sp_CACompetency_FinalizeCompetency(CompetencyAssessmentID, Convert.ToInt32(Session["EmployeeID"]), "NULL", LastSix).FirstOrDefault();

                    var json = jsonSerialiser.Serialize(result);
                    return json;
               
            }
        }

        public void UpdatePercentComplete(int CompetencyAssessmentID, int percent)
        {           
            try
            {
                // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                    var result = context.EmployeeAssessmentHeaders.SingleOrDefault(b => b.CompetencyAssessmentID == CompetencyAssessmentID);
                    result.PercentComplete = percent;
                    result.ModifiedDateTime = DateTime.Now;
                    result.ModifiedEmployeeID = Convert.ToInt32(Session["EmployeeID"]);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
            }
        }

    }
}