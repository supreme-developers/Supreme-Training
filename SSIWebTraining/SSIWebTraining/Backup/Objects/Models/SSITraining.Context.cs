﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSIWebTraining.Objects.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SSITrainingEntities : DbContext
    {
        public SSITrainingEntities()
            : base("name=SSITrainingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Competency> Competencies { get; set; }
        public virtual DbSet<CompetencyDefHeader> CompetencyDefHeaders { get; set; }
        public virtual DbSet<CompetencyGroup> CompetencyGroups { get; set; }
        public virtual DbSet<tblCACompetency_Status> tblCACompetency_Status { get; set; }
        public virtual DbSet<CompetencyType> CompetencyTypes { get; set; }
        public virtual DbSet<CompetencyTask> CompetencyTasks { get; set; }
        public virtual DbSet<tblCACompetency_AssessmentDetails> tblCACompetency_AssessmentDetails { get; set; }
        public virtual DbSet<tblCACompetency_AssessmentHeader> tblCACompetency_AssessmentHeader { get; set; }
        public virtual DbSet<tblCACompetency_ManagerAccess> tblCACompetency_ManagerAccess { get; set; }
    
        public virtual ObjectResult<Nullable<int>> sp_CACompetency_AddEditCompetency(Nullable<int> competencyID, Nullable<int> competencyGroupID, string question, string answer, Nullable<int> competencyTypeID, Nullable<int> levelID, Nullable<int> userID)
        {
            var competencyIDParameter = competencyID.HasValue ?
                new ObjectParameter("CompetencyID", competencyID) :
                new ObjectParameter("CompetencyID", typeof(int));
    
            var competencyGroupIDParameter = competencyGroupID.HasValue ?
                new ObjectParameter("CompetencyGroupID", competencyGroupID) :
                new ObjectParameter("CompetencyGroupID", typeof(int));
    
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var answerParameter = answer != null ?
                new ObjectParameter("Answer", answer) :
                new ObjectParameter("Answer", typeof(string));
    
            var competencyTypeIDParameter = competencyTypeID.HasValue ?
                new ObjectParameter("CompetencyTypeID", competencyTypeID) :
                new ObjectParameter("CompetencyTypeID", typeof(int));
    
            var levelIDParameter = levelID.HasValue ?
                new ObjectParameter("LevelID", levelID) :
                new ObjectParameter("LevelID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_CACompetency_AddEditCompetency", competencyIDParameter, competencyGroupIDParameter, questionParameter, answerParameter, competencyTypeIDParameter, levelIDParameter, userIDParameter);
        }
    
        public virtual int sp_CACompetency_SetStatus(Nullable<int> compID, string statusCode)
        {
            var compIDParameter = compID.HasValue ?
                new ObjectParameter("CompID", compID) :
                new ObjectParameter("CompID", typeof(int));
    
            var statusCodeParameter = statusCode != null ?
                new ObjectParameter("StatusCode", statusCode) :
                new ObjectParameter("StatusCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_SetStatus", compIDParameter, statusCodeParameter);
        }
    
        public virtual int sp_CACompetency_InsertCompetencyDefDetail(Nullable<int> compDefHeaderID, Nullable<int> competencyID, Nullable<int> userID)
        {
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            var competencyIDParameter = competencyID.HasValue ?
                new ObjectParameter("CompetencyID", competencyID) :
                new ObjectParameter("CompetencyID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_InsertCompetencyDefDetail", compDefHeaderIDParameter, competencyIDParameter, userIDParameter);
        }
    
        public virtual int sp_CACompetency_RemoveCompfromDefinition(Nullable<int> competencyID, Nullable<int> competencyDefHeaderID, Nullable<int> userID)
        {
            var competencyIDParameter = competencyID.HasValue ?
                new ObjectParameter("CompetencyID", competencyID) :
                new ObjectParameter("CompetencyID", typeof(int));
    
            var competencyDefHeaderIDParameter = competencyDefHeaderID.HasValue ?
                new ObjectParameter("CompetencyDefHeaderID", competencyDefHeaderID) :
                new ObjectParameter("CompetencyDefHeaderID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_RemoveCompfromDefinition", competencyIDParameter, competencyDefHeaderIDParameter, userIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetCompetencyDefinitions_Result> sp_CACompetency_GetCompetencyDefinitions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetCompetencyDefinitions_Result>("sp_CACompetency_GetCompetencyDefinitions");
        }
    
        public virtual int CompetencyHeader(Nullable<int> compDefHeaderID)
        {
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CompetencyHeader", compDefHeaderIDParameter);
        }
    
        public virtual int sp_CACompetency_RemoveCompetencyDefinition(Nullable<int> compDefHeaderID, Nullable<int> userID)
        {
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_RemoveCompetencyDefinition", compDefHeaderIDParameter, userIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetManagerEmployees_Result> sp_CACompetency_GetManagerEmployees(Nullable<int> managerUserID)
        {
            var managerUserIDParameter = managerUserID.HasValue ?
                new ObjectParameter("ManagerUserID", managerUserID) :
                new ObjectParameter("ManagerUserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetManagerEmployees_Result>("sp_CACompetency_GetManagerEmployees", managerUserIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetEmployeeCompetencies_Result> sp_CACompetency_GetEmployeeCompetencies(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetEmployeeCompetencies_Result>("sp_CACompetency_GetEmployeeCompetencies", employeeIDParameter);
        }
    
        public virtual int sp_CACompetency_UpdateSorts(Nullable<int> oldSort, Nullable<int> newSort, Nullable<int> compDefHeaderID, Nullable<int> userID)
        {
            var oldSortParameter = oldSort.HasValue ?
                new ObjectParameter("oldSort", oldSort) :
                new ObjectParameter("oldSort", typeof(int));
    
            var newSortParameter = newSort.HasValue ?
                new ObjectParameter("newSort", newSort) :
                new ObjectParameter("newSort", typeof(int));
    
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_UpdateSorts", oldSortParameter, newSortParameter, compDefHeaderIDParameter, userIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetCompetencyHeaderDetails_Result> sp_CACompetency_GetCompetencyHeaderDetails(Nullable<int> compDefHeaderID)
        {
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetCompetencyHeaderDetails_Result>("sp_CACompetency_GetCompetencyHeaderDetails", compDefHeaderIDParameter);
        }
    
        public virtual int sp_CACompetency_DeleteTask(Nullable<int> compDefTaskID, Nullable<int> compDefHeaderID, Nullable<int> userID)
        {
            var compDefTaskIDParameter = compDefTaskID.HasValue ?
                new ObjectParameter("CompDefTaskID", compDefTaskID) :
                new ObjectParameter("CompDefTaskID", typeof(int));
    
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_DeleteTask", compDefTaskIDParameter, compDefHeaderIDParameter, userIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetAssessors_Result> sp_CACompetency_GetAssessors()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetAssessors_Result>("sp_CACompetency_GetAssessors");
        }
    
        public virtual ObjectResult<sp_CACompetency_GetManagerJobQualification_Access_Result> sp_CACompetency_GetManagerJobQualification_Access(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetManagerJobQualification_Access_Result>("sp_CACompetency_GetManagerJobQualification_Access", employeeIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetManagerJobRoles_Access_Result> sp_CACompetency_GetManagerJobRoles_Access(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetManagerJobRoles_Access_Result>("sp_CACompetency_GetManagerJobRoles_Access", employeeIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetManagerJobTitle_Access_Result> sp_CACompetency_GetManagerJobTitle_Access(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetManagerJobTitle_Access_Result>("sp_CACompetency_GetManagerJobTitle_Access", employeeIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_CACompetency_CompetencyDefHeader_Insert(Nullable<int> jobTitleID, Nullable<int> jobRoleID, Nullable<int> jobResponsibilityID, string description, Nullable<short> passingGrade, Nullable<short> notifyDays, string notifyEmail, Nullable<short> recurrenceQty, Nullable<int> uOMSchedulingRecurrenceID, Nullable<short> failure_RecurrenceQty, Nullable<int> failure_UOMSchedulingRecurrenceID, Nullable<int> userID)
        {
            var jobTitleIDParameter = jobTitleID.HasValue ?
                new ObjectParameter("JobTitleID", jobTitleID) :
                new ObjectParameter("JobTitleID", typeof(int));
    
            var jobRoleIDParameter = jobRoleID.HasValue ?
                new ObjectParameter("JobRoleID", jobRoleID) :
                new ObjectParameter("JobRoleID", typeof(int));
    
            var jobResponsibilityIDParameter = jobResponsibilityID.HasValue ?
                new ObjectParameter("JobResponsibilityID", jobResponsibilityID) :
                new ObjectParameter("JobResponsibilityID", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var passingGradeParameter = passingGrade.HasValue ?
                new ObjectParameter("PassingGrade", passingGrade) :
                new ObjectParameter("PassingGrade", typeof(short));
    
            var notifyDaysParameter = notifyDays.HasValue ?
                new ObjectParameter("NotifyDays", notifyDays) :
                new ObjectParameter("NotifyDays", typeof(short));
    
            var notifyEmailParameter = notifyEmail != null ?
                new ObjectParameter("NotifyEmail", notifyEmail) :
                new ObjectParameter("NotifyEmail", typeof(string));
    
            var recurrenceQtyParameter = recurrenceQty.HasValue ?
                new ObjectParameter("RecurrenceQty", recurrenceQty) :
                new ObjectParameter("RecurrenceQty", typeof(short));
    
            var uOMSchedulingRecurrenceIDParameter = uOMSchedulingRecurrenceID.HasValue ?
                new ObjectParameter("UOMSchedulingRecurrenceID", uOMSchedulingRecurrenceID) :
                new ObjectParameter("UOMSchedulingRecurrenceID", typeof(int));
    
            var failure_RecurrenceQtyParameter = failure_RecurrenceQty.HasValue ?
                new ObjectParameter("Failure_RecurrenceQty", failure_RecurrenceQty) :
                new ObjectParameter("Failure_RecurrenceQty", typeof(short));
    
            var failure_UOMSchedulingRecurrenceIDParameter = failure_UOMSchedulingRecurrenceID.HasValue ?
                new ObjectParameter("Failure_UOMSchedulingRecurrenceID", failure_UOMSchedulingRecurrenceID) :
                new ObjectParameter("Failure_UOMSchedulingRecurrenceID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_CACompetency_CompetencyDefHeader_Insert", jobTitleIDParameter, jobRoleIDParameter, jobResponsibilityIDParameter, descriptionParameter, passingGradeParameter, notifyDaysParameter, notifyEmailParameter, recurrenceQtyParameter, uOMSchedulingRecurrenceIDParameter, failure_RecurrenceQtyParameter, failure_UOMSchedulingRecurrenceIDParameter, userIDParameter);
        }
    
        public virtual int sp_CACompetency_CompetencyDefHeader_Update(Nullable<int> compDefHeaderID, Nullable<int> jobTitleID, Nullable<int> jobRoleID, Nullable<int> jobResponsibilityID, string description, Nullable<short> passingGrade, Nullable<short> notifyDays, string notifyEmail, Nullable<short> recurrenceQty, Nullable<int> uOMSchedulingRecurrenceID, Nullable<short> failure_RecurrenceQty, Nullable<int> failure_UOMSchedulingRecurrenceID, Nullable<int> userID)
        {
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            var jobTitleIDParameter = jobTitleID.HasValue ?
                new ObjectParameter("JobTitleID", jobTitleID) :
                new ObjectParameter("JobTitleID", typeof(int));
    
            var jobRoleIDParameter = jobRoleID.HasValue ?
                new ObjectParameter("JobRoleID", jobRoleID) :
                new ObjectParameter("JobRoleID", typeof(int));
    
            var jobResponsibilityIDParameter = jobResponsibilityID.HasValue ?
                new ObjectParameter("JobResponsibilityID", jobResponsibilityID) :
                new ObjectParameter("JobResponsibilityID", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var passingGradeParameter = passingGrade.HasValue ?
                new ObjectParameter("PassingGrade", passingGrade) :
                new ObjectParameter("PassingGrade", typeof(short));
    
            var notifyDaysParameter = notifyDays.HasValue ?
                new ObjectParameter("NotifyDays", notifyDays) :
                new ObjectParameter("NotifyDays", typeof(short));
    
            var notifyEmailParameter = notifyEmail != null ?
                new ObjectParameter("NotifyEmail", notifyEmail) :
                new ObjectParameter("NotifyEmail", typeof(string));
    
            var recurrenceQtyParameter = recurrenceQty.HasValue ?
                new ObjectParameter("RecurrenceQty", recurrenceQty) :
                new ObjectParameter("RecurrenceQty", typeof(short));
    
            var uOMSchedulingRecurrenceIDParameter = uOMSchedulingRecurrenceID.HasValue ?
                new ObjectParameter("UOMSchedulingRecurrenceID", uOMSchedulingRecurrenceID) :
                new ObjectParameter("UOMSchedulingRecurrenceID", typeof(int));
    
            var failure_RecurrenceQtyParameter = failure_RecurrenceQty.HasValue ?
                new ObjectParameter("Failure_RecurrenceQty", failure_RecurrenceQty) :
                new ObjectParameter("Failure_RecurrenceQty", typeof(short));
    
            var failure_UOMSchedulingRecurrenceIDParameter = failure_UOMSchedulingRecurrenceID.HasValue ?
                new ObjectParameter("Failure_UOMSchedulingRecurrenceID", failure_UOMSchedulingRecurrenceID) :
                new ObjectParameter("Failure_UOMSchedulingRecurrenceID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_CompetencyDefHeader_Update", compDefHeaderIDParameter, jobTitleIDParameter, jobRoleIDParameter, jobResponsibilityIDParameter, descriptionParameter, passingGradeParameter, notifyDaysParameter, notifyEmailParameter, recurrenceQtyParameter, uOMSchedulingRecurrenceIDParameter, failure_RecurrenceQtyParameter, failure_UOMSchedulingRecurrenceIDParameter, userIDParameter);
        }
    
        public virtual int sp_CACompetency_ManagerAssignments_Add(Nullable<int> objectID, string objectType, Nullable<int> employeeID, Nullable<int> userID)
        {
            var objectIDParameter = objectID.HasValue ?
                new ObjectParameter("ObjectID", objectID) :
                new ObjectParameter("ObjectID", typeof(int));
    
            var objectTypeParameter = objectType != null ?
                new ObjectParameter("ObjectType", objectType) :
                new ObjectParameter("ObjectType", typeof(string));
    
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_ManagerAssignments_Add", objectIDParameter, objectTypeParameter, employeeIDParameter, userIDParameter);
        }
    
        public virtual int sp_CACompetency_ManagerAssignments_Remove(Nullable<int> objectID, string objectType, Nullable<int> employeeID, Nullable<int> userID)
        {
            var objectIDParameter = objectID.HasValue ?
                new ObjectParameter("ObjectID", objectID) :
                new ObjectParameter("ObjectID", typeof(int));
    
            var objectTypeParameter = objectType != null ?
                new ObjectParameter("ObjectType", objectType) :
                new ObjectParameter("ObjectType", typeof(string));
    
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_ManagerAssignments_Remove", objectIDParameter, objectTypeParameter, employeeIDParameter, userIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetActiveEmployees_Result> sp_CACompetency_GetActiveEmployees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetActiveEmployees_Result>("sp_CACompetency_GetActiveEmployees");
        }
    
        public virtual ObjectResult<sp_CACompetency_GetAllAssessors_Result> sp_CACompetency_GetAllAssessors()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetAllAssessors_Result>("sp_CACompetency_GetAllAssessors");
        }
    
        public virtual ObjectResult<sp_CACompetency_GetSnapshotEmployees_Result> sp_CACompetency_GetSnapshotEmployees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetSnapshotEmployees_Result>("sp_CACompetency_GetSnapshotEmployees");
        }
    
        public virtual ObjectResult<sp_CACompetency_GetAllEmployeeCompetencies_Result1> sp_CACompetency_GetAllEmployeeCompetencies(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetAllEmployeeCompetencies_Result1>("sp_CACompetency_GetAllEmployeeCompetencies", employeeIDParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetUnAssigned_CompetencyDefinitions_Result> sp_CACompetency_GetUnAssigned_CompetencyDefinitions(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetUnAssigned_CompetencyDefinitions_Result>("sp_CACompetency_GetUnAssigned_CompetencyDefinitions", employeeIDParameter);
        }
    
        public virtual int sp_CACompetency_AddCompetency_toEmployeeSnapshot(Nullable<int> employeeID, Nullable<int> compDefHeaderID, Nullable<int> userID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_AddCompetency_toEmployeeSnapshot", employeeIDParameter, compDefHeaderIDParameter, userIDParameter);
        }
    
        public virtual int sp_CACompetency_DeleteCompetency_fromEmployeeSnapshot(Nullable<int> employeeID, Nullable<int> compDefHeaderID, Nullable<int> userID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            var compDefHeaderIDParameter = compDefHeaderID.HasValue ?
                new ObjectParameter("CompDefHeaderID", compDefHeaderID) :
                new ObjectParameter("CompDefHeaderID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CACompetency_DeleteCompetency_fromEmployeeSnapshot", employeeIDParameter, compDefHeaderIDParameter, userIDParameter);
        }
    
        public virtual ObjectResult<sp_sys_GetMobileLogin_Result> sp_sys_GetMobileLogin(string lastSix)
        {
            var lastSixParameter = lastSix != null ?
                new ObjectParameter("LastSix", lastSix) :
                new ObjectParameter("LastSix", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_sys_GetMobileLogin_Result>("sp_sys_GetMobileLogin", lastSixParameter);
        }
    
        public virtual ObjectResult<sp_CACompetency_GetAssessor_Assessments_Result> sp_CACompetency_GetAssessor_Assessments(Nullable<int> assessorID)
        {
            var assessorIDParameter = assessorID.HasValue ?
                new ObjectParameter("AssessorID", assessorID) :
                new ObjectParameter("AssessorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CACompetency_GetAssessor_Assessments_Result>("sp_CACompetency_GetAssessor_Assessments", assessorIDParameter);
        }
    }
}
