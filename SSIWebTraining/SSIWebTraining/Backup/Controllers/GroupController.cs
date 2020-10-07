using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSIWebTraining.Objects.Models;
using System.Web.Script.Serialization;
namespace SSIWebTraining.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public JsonResult AddGroup(CompetencyGroup Group)
        {
            using (var context = new SSITrainingEntities())
            {
                string name = Group.GroupName;
                Group.CreateDateTime = DateTime.Now;
                Group.CreateUserId = Convert.ToInt32(Session["USERID"]);
                context.CompetencyGroups.Add(Group);
                context.SaveChanges();
                return Json(new { status = "Group Added Successfully!!" });
            }
        }
        public JsonResult EditGroup(CompetencyGroup updatedGroup)
        {
            CompetencyGroup group = new CompetencyGroup();
            string status;
            using (SSITrainingEntities entity = new SSITrainingEntities())
            {
                var result = entity.CompetencyGroups.SingleOrDefault(g => g.CompetencyGroupID == updatedGroup.CompetencyGroupID);
                if (result != null)
                {
                    result.GroupName = updatedGroup.GroupName;
                    result.ModifiedUserID = 137;
                    result.ModifiedDateTime = DateTime.Now;
                    entity.SaveChanges();
                    status = "Group Updated";
                }
                else
                    status = "Cannot update this group b/c it no longer exists.";
            }
            return Json(new { status });

        }
        public void DeleteGroup(CompetencyGroup group)
        {
            var compGroup = new CompetencyGroup { CompetencyGroupID = group.CompetencyGroupID };
            using (SSITrainingEntities context = new SSITrainingEntities())
            {
                context.CompetencyGroups.Attach(compGroup);
                context.CompetencyGroups.Remove(compGroup);
                context.SaveChanges();
            }
        }
        public string GetGroups()
        {
             List<CompetencyGroup> groupList = new List<CompetencyGroup>();
            var jsonSerialiser = new JavaScriptSerializer();
            using (var db = new SSITrainingEntities())
            {
                //return (from g in db.CompetencyGroups
                //        select g).ToList();
                groupList = db.CompetencyGroups.ToList();
            }
            var json = jsonSerialiser.Serialize(groupList);
            return json;
            //var j = Json(new { Response = groupList }, JsonRequestBehavior.AllowGet);
            //return j;
            //return groupList;
        }
       
    }
}