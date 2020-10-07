using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSIWebTraining.Objects.Models;
using System.Data.Entity.Core.Objects;
using System.Web.Script.Serialization;
using System.Data.Entity;
using System.Dynamic;

namespace SSIWebTraining.Controllers
{
    public class CompetencyController : Controller
    {
        // GET: Competency
        public Competency AddEditComp(Competency comp)
        {

            using (var context = new SSITrainingEntities())
            {
                try
                {
                    var result = context.sp_CACompetency_AddEditCompetency(comp.CompetencyID, comp.CompetencyGroupID, comp.Question,
                        comp.Answer, comp.CompetencyTypeID, comp.LevelID, Convert.ToInt32(Session["USERID"]));
                    if (comp.CompetencyID == 0) //if this is true, then this is a Competency Insert, otherwise, it's an edit.
                    {
                        comp.CompetencyID = Convert.ToInt32(result);
                        comp.CreateUserID = Convert.ToInt32(Session["USERID"]);
                    }

                }
                catch (Exception ex)
                {

                }
                return comp;
            }
        }

        public string SetCompStatus(int compID, string statusCode)
        {
            var msg = "Competency Deleted Successfully!";
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    context.sp_CACompetency_SetStatus(compID, statusCode);
                }
                catch (Exception ex)
                {
                    msg = "Error Delete Competency. Please Contact IT with the following message: " + ex.Message;
                }
            }
            return msg;
        }
        public string GetCompetencies(int GroupID)
        {
            var compList = new List<Competency>();
            var jsonSerialiser = new JavaScriptSerializer();
            using (var db = new SSITrainingEntities())
            {
                var query = from x in db.Competencies
                            join s in db.tblCACompetency_Status on x.CompetencyStatusID equals s.CompetencyStatusID
                            join t in db.CompetencyTypes on x.CompetencyTypeID equals t.CompetencyTypeID
                            where x.CompetencyGroupID == GroupID && s.ObjectStatusCode == "Active"

                            select new
                            {
                                CompetencyID = x.CompetencyID,
                                CompetencyGroupID = x.CompetencyGroupID,
                                CompetencyStatusID = x.CompetencyStatusID,
                                Question = x.Question,
                                Answer = x.Answer,
                                CompetencyTypeID = x.CompetencyTypeID,
                                LevelID = x.LevelID,
                                CompetencyTypeName = t.CompetencyTypeName
                            };
                compList = query.ToList().Select(x => new Competency
                {
                    CompetencyID = x.CompetencyID,
                    CompetencyGroupID = x.CompetencyGroupID,
                    CompetencyStatusID = x.CompetencyStatusID,
                    Question = x.Question,
                    Answer = x.Answer,
                    CompetencyTypeID = x.CompetencyTypeID,
                    LevelID = x.LevelID,
                    CompetencyTypeName = x.CompetencyTypeName
                }).ToList();
            }
            var json = jsonSerialiser.Serialize(compList);
            return json;
            //var j = Json(new { Response = groupList }, JsonRequestBehavior.AllowGet);
            //return j;
            //return groupList;
        }
        public string GetCompetency(int CompID)
        {
            // var compList = new Competency();
            var jsonSerialiser = new JavaScriptSerializer();
            // var compList = new Object(); 
            using (var db = new SSITrainingEntities())
            {
                var compList = from x in db.Competencies
                               where x.CompetencyID == CompID
                               select new
                               {
                                   CompetencyID = x.CompetencyID,
                                   CompetencyGroupID = x.CompetencyGroupID,
                                   CompetencyStatusID = x.CompetencyStatusID,
                                   Question = x.Question,
                                   Answer = x.Answer,
                                   CompetencyTypeID = x.CompetencyTypeID,
                                   LevelID = x.LevelID
                               };
                var json = jsonSerialiser.Serialize(compList);
                return json;
            }

        }
        public string GetCompetencyTypes()
        {
            var typeList = new List<CompetencyType>();
            var jsonSerialiser = new JavaScriptSerializer();
            using (var db = new SSITrainingEntities())
            {
                var query = from x in db.CompetencyTypes

                            select new
                            {
                                CompetencyTypeID = x.CompetencyTypeID,
                                CompetencyTypeName = x.CompetencyTypeName

                            };
                typeList = query.ToList().Select(x => new CompetencyType
                {
                    CompetencyTypeID = x.CompetencyTypeID,
                    CompetencyTypeName = x.CompetencyTypeName
                }).ToList();
            }
            var json = jsonSerialiser.Serialize(typeList);
            return json;
        }
        public int? InsertHeader(CompetencyDefHeader header)
        {
            var result = (int?)null;
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    result = context.sp_CACompetency_CompetencyDefHeader_Insert(header.JobTitleID, header.JobRoleID, header.JobResponsibilityID, header.Description, header.PassingGrade,
                                  header.NotifyDays,header.NotifyEmail, header.RecurrenceQty, header.UOMSchedulingRecurrenceID,header.Failure_RecurrenceQty, header.Failure_UOMSchedulingRecurrenceID,
                                  Convert.ToInt32(Session["UserID"])).FirstOrDefault();

                    header.CompDefHeaderID = Convert.ToInt32(result);

                }
                catch (Exception ex)
                {

                }
                return result;
            }
        }
        public string UpdateHeader(CompetencyDefHeader header)
        {
            // var result = (int?)null;
            string result = "";
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    context.sp_CACompetency_CompetencyDefHeader_Update(header.CompDefHeaderID, header.JobTitleID, header.JobRoleID, header.JobResponsibilityID, header.Description, header.PassingGrade,
                                  header.NotifyDays, header.NotifyEmail, header.RecurrenceQty, header.UOMSchedulingRecurrenceID, header.Failure_RecurrenceQty, header.Failure_UOMSchedulingRecurrenceID, Convert.ToInt32(Session["UserID"]));
                    result = "Success";
                    // header.CompDefHeaderID = Convert.ToInt32(result);

                }
                catch (Exception ex)
                {
                    result = "Update was not successful. Here's why:" + ex.Message;
                }
                return result;
            }
        }
        public void InsertDetail(int compHeaderID, int CompetencyID)
        {
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    context.sp_CACompetency_InsertCompetencyDefDetail(compHeaderID, CompetencyID, Convert.ToInt32(Session["UserID"]));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        //public string GetCompetencies_withDefHeader(int GroupID, int compHeaderID)
        //{
        //    var compList = new List<Competency>();
        //    var jsonSerialiser = new JavaScriptSerializer();
        //    using (var db = new SSITrainingEntities())
        //    {
        //        var query = from x in db.Competencies
        //                    join s in db.tblCACompetency_Status on x.CompetencyStatusID equals s.CompetencyStatusID
        //                    join t in db.CompetencyTypes on x.CompetencyTypeID equals t.CompetencyTypeID
        //                    join d in db.CompetencyDefDetails on x.CompetencyID equals d.CompetencyID into leftjoin
        //                    from dd in leftjoin.Where(f => f.CompDefHeaderID == compHeaderID && f.Active == true).DefaultIfEmpty()
        //                    where x.CompetencyGroupID == GroupID && s.ObjectStatusCode == "Active"

        //                    select new
        //                    {
        //                        CompetencyID = x.CompetencyID,
        //                        CompetencyGroupID = x.CompetencyGroupID,
        //                        CompetencyStatusID = x.CompetencyStatusID,
        //                        Question = x.Question,
        //                        Answer = x.Answer,
        //                        CompetencyTypeID = x.CompetencyTypeID,
        //                        LevelID = x.LevelID,
        //                        CompetencyTypeName = t.CompetencyTypeName
        //                        ,
        //                        CompDefHeaderID = (dd.CompDefHeaderID == null) ? 0 : dd.CompDefHeaderID
        //                    };
        //        try
        //        {
        //            compList = query.ToList().Select(x => new Competency
        //            {
        //                CompetencyID = x.CompetencyID,
        //                CompetencyGroupID = x.CompetencyGroupID,
        //                CompetencyStatusID = x.CompetencyStatusID,
        //                Question = x.Question,
        //                Answer = x.Answer,
        //                CompetencyTypeID = x.CompetencyTypeID,
        //                LevelID = x.LevelID,
        //                CompetencyTypeName = x.CompetencyTypeName
        //                ,
        //                CompDefHeaderID = x.CompDefHeaderID
        //            }).ToList();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }


        //    var json = jsonSerialiser.Serialize(compList);
        //    return json;

        //}
        //public string GetCompDefDetails(int compHeaderID)
        //{
        //    var compList = new List<Competency>();
        //    var jsonSerialiser = new JavaScriptSerializer();
        //    using (var db = new SSITrainingEntities())
        //    {
        //        var query = from x in db.Competencies
        //                    join d in db.CompetencyDefDetails on x.CompetencyID equals d.CompetencyID
        //                    join s in db.tblCACompetency_Status on x.CompetencyStatusID equals s.CompetencyStatusID
        //                    join t in db.CompetencyTypes on x.CompetencyTypeID equals t.CompetencyTypeID
        //                    where d.CompDefHeaderID == compHeaderID && s.ObjectStatusCode == "Active" && d.Active == true

        //                    select new
        //                    {
        //                        CompetencyID = x.CompetencyID,
        //                        CompetencyGroupID = x.CompetencyGroupID,
        //                        CompetencyStatusID = x.CompetencyStatusID,
        //                        Question = x.Question,
        //                        Answer = x.Answer,
        //                        CompetencyTypeID = x.CompetencyTypeID,
        //                        LevelID = x.LevelID,
        //                        CompetencyTypeName = t.CompetencyTypeName
        //                    };
        //        compList = query.ToList().Select(x => new Competency
        //        {
        //            CompetencyID = x.CompetencyID,
        //            CompetencyGroupID = x.CompetencyGroupID,
        //            CompetencyStatusID = x.CompetencyStatusID,
        //            Question = x.Question,
        //            Answer = x.Answer,
        //            CompetencyTypeID = x.CompetencyTypeID,
        //            LevelID = x.LevelID,
        //            CompetencyTypeName = x.CompetencyTypeName
        //        }).ToList();
        //    }
        //    var json = jsonSerialiser.Serialize(compList);
        //    return json;
        //}
        public string GetCompHeaderDetails(int compHeaderID)
        {
            //CompetencyDefHeader CompDefHeader = new CompetencyDefHeader();
            var jsonSerialiser = new JavaScriptSerializer();
            using (var db = new SSITrainingEntities())
            {
                var compDefHeader = db.sp_CACompetency_GetCompetencyHeaderDetails(compHeaderID).Single();

                var json = jsonSerialiser.Serialize(compDefHeader);
                return json;
            }
        }
        public void RemoveCompetency_fromDefinition(int CompetencyID, int compDefHeaderID)
        {
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    context.sp_CACompetency_RemoveCompfromDefinition(CompetencyID, compDefHeaderID, Convert.ToInt32(Session["UserID"]));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void RemoveCompetencyDefinition(int compDefHeaderID)
        {
            using (var context = new SSITrainingEntities())
            {
                try
                {
                    context.sp_CACompetency_RemoveCompetencyDefinition(compDefHeaderID, Convert.ToInt32(Session["UserID"]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }        
        public Array GetCompetencyDefinitions()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var listOfStrings = new List<string>();
            string[] arrayOfStrings = listOfStrings.ToArray();
            try {
              
                using (var db = new SSITrainingEntities())
                {
                    var result = db.sp_CACompetency_GetCompetencyDefinitions().ToArray();


                    var json = jsonSerialiser.Serialize(result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return arrayOfStrings;
            }
        }
        public int? GetTaskMaxSort(int? compDefHeader)
        {
            int? maxSort = 0;
            try
            {
                // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                    maxSort = context.CompetencyTasks.Where(h => h.CompDefHeaderID == compDefHeader).Max(s => s.Sort);
                }
            }
            catch (Exception ex)
            {
                
            }
            return maxSort = (maxSort ?? 0) + 1;
        }
        public JsonResult AddTask(CompetencyTask compTask)
        {            
            try {
               // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                    compTask.Sort = GetTaskMaxSort(compTask.CompDefHeaderID);
                    compTask.CreateDateTime = DateTime.Now;
                    compTask.CreateUserID = Convert.ToInt32(Session["USERID"]);

                    context.CompetencyTasks.Add(compTask);
                    context.SaveChanges();
                    return Json(new { status = "Task Added Successfully!!" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { status = ex.Message });
            }
        }
        public string UpdateTask(CompetencyTask compTask)
        {
            // var result = (int?)null;
            string result = "";
            try
            {
                // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                    compTask.ModifiedDateTime = DateTime.Now;
                    compTask.ModifiedUserID = Convert.ToInt32(Session["USERID"]);
                    context.CompetencyTasks.Attach(compTask);

                    var entry = context.Entry(compTask);
                    entry.Property(t => t.Task).IsModified = true;
                    entry.Property(t => t.ModifiedUserID).IsModified = true;
                    entry.Property(t => t.ModifiedDateTime).IsModified = true;
                    entry.Property(t => t.Sort).IsModified = true;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = "Task Update Failed";
                Console.WriteLine(result);
            }
            return result;
        }
        public string DeleteTask(CompetencyTask compTask)
        {
            // var result = (int?)null;
            string result = "";
            try
            {
                // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                    context.sp_CACompetency_DeleteTask(compTask.CompDefTaskID,compTask.CompDefHeaderID, Convert.ToInt32(Session["UserID"]));
                    //compTask.Active = false;
                    //compTask.ModifiedDateTime = DateTime.Now;
                    //compTask.ModifiedUserID = Convert.ToInt32(Session["USERID"]);
                    //context.CompetencyTasks.Attach(compTask);

                    //var entry = context.Entry(compTask);
                    //entry.Property(t => t.Active).IsModified = true;
                    //entry.Property(t => t.ModifiedUserID).IsModified = true;
                    //entry.Property(t => t.ModifiedDateTime).IsModified = true;

                    //context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = "Task Update Failed";
                Console.WriteLine(result);
            }
            return result;
        }
        public string UpdateAllTaskSorts(int oldSort, int newSort, int compDefHeader)
        {
            string result = "Successfull";
            try
            {
                // CompetencyTask cTask = new CompetencyTask();
                using (var context = new SSITrainingEntities())
                {
                   context.sp_CACompetency_UpdateSorts(oldSort, newSort, compDefHeader, Convert.ToInt32(Session["UserID"]));
                }
            }
            catch (Exception ex)
            {
                result = "Failed To Update All Tasks";
            }
            return result;
        }
        public string GetCurrentTasks(int compDefHeaderID)
        {
            var taskList = new List<CompetencyTask>();
            var jsonSerialiser = new JavaScriptSerializer();
            string json = "";

            try {
                using (var db = new SSITrainingEntities())
                {
                    var query = from x in db.CompetencyTasks
                                where x.CompDefHeaderID == compDefHeaderID && x.Active == true
                                select x;
                    taskList = query.OrderBy(t => t.Sort).ToList();
                    json = jsonSerialiser.Serialize(taskList);

                }

                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return json;
        }
        /*var compList = new List<Competency>();
            var jsonSerialiser = new JavaScriptSerializer();
            using (var db = new SSITrainingEntities())
            {
                var query = from x in db.Competencies
                            join s in db.tblCACompetency_Status on x.CompetencyStatusID equals s.CompetencyStatusID
                            join t in db.CompetencyTypes on x.CompetencyTypeID equals t.CompetencyTypeID
                            where x.CompetencyGroupID == GroupID && s.ObjectStatusCode == "Active"

                            select new
                            {
                                CompetencyID = x.CompetencyID,
                                CompetencyGroupID = x.CompetencyGroupID,
                                CompetencyStatusID = x.CompetencyStatusID,
                                Question = x.Question,
                                Answer = x.Answer,
                                CompetencyTypeID = x.CompetencyTypeID,
                                LevelID = x.LevelID,
                                CompetencyTypeName = t.CompetencyTypeName
                            };
                compList = query.ToList().Select(x => new Competency
                {
                    CompetencyID = x.CompetencyID,
                    CompetencyGroupID = x.CompetencyGroupID,
                    CompetencyStatusID = x.CompetencyStatusID,
                    Question = x.Question,
                    Answer = x.Answer,
                    CompetencyTypeID = x.CompetencyTypeID,
                    LevelID = x.LevelID,
                    CompetencyTypeName = x.CompetencyTypeName
                }).ToList();
            }
            var json = jsonSerialiser.Serialize(compList);
            return json;*/

    }
}
