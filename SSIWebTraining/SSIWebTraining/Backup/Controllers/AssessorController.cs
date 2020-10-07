using SSIWebTraining.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SSIWebTraining.Controllers
{
    public class AssessorController : Controller
    {
        public string GetEmployees()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            using (var db = new SSITrainingEntities())
            {
                var assessors = db.sp_CACompetency_GetActiveEmployees().ToList();

                var json = jsonSerialiser.Serialize(assessors);
                return json;
            }
        }
        public string GetAssessors()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            using (var db = new SSITrainingEntities())
            {
                var assessors = db.sp_CACompetency_GetAllAssessors().ToList();

                var json = jsonSerialiser.Serialize(assessors);
                return json;
            }
        }
        public string GetJobRoles(int EmployeeID)
        {
            var jsonSerialiser = new JavaScriptSerializer();
           
            string jobRoleList = "";
            
            try
            {
                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetManagerJobRoles_Access(EmployeeID).ToArray();

                    var json = jsonSerialiser.Serialize(result);
                    jobRoleList = json;                   
                }
                
            }
            catch (Exception ex)
            {

            }
            return jobRoleList;

        }
        public string GetJobTitles(int EmployeeID)
        {
            var jsonSerialiser = new JavaScriptSerializer();

            string jobTitleList = "";

            try
            {
                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetManagerJobTitle_Access(EmployeeID).ToArray();

                    var json = jsonSerialiser.Serialize(result);
                    jobTitleList = json;
                }

            }
            catch (Exception ex)
            {

            }
            return jobTitleList;

        }
        public string GetJobResps(int EmployeeID)
        {
            var jsonSerialiser = new JavaScriptSerializer();

            string jobespList = "";

            try
            {
                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetManagerJobQualification_Access(EmployeeID).ToArray();

                    var json = jsonSerialiser.Serialize(result);
                    jobespList = json;
                }

            }
            catch (Exception ex)
            {

            }
            return jobespList;

        }

        public void ManagerAssignments(int ObjectID, string ObjectType, int EmployeeID)
        {
            try
            {
                // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                    context.sp_CACompetency_ManagerAssignments_Add(ObjectID, ObjectType, EmployeeID, Convert.ToInt32(Session["USERID"]));
                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoveManagerAssignments(int ObjectID, string ObjectType, int EmployeeID)
        {
            try
            {
                // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                    context.sp_CACompetency_ManagerAssignments_Remove(ObjectID, ObjectType, EmployeeID, Convert.ToInt32(Session["USERID"]));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}                                            