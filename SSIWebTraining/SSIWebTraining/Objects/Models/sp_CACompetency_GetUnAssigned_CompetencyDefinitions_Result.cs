//------------------------------------------------------------------------------
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
    
    public partial class sp_CACompetency_GetUnAssigned_CompetencyDefinitions_Result
    {
        public string DefinedBy { get; set; }
        public string Recurrence { get; set; }
        public int CompDefHeaderID { get; set; }
        public Nullable<int> JobTitleID { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public Nullable<int> JobResponsibilityID { get; set; }
        public string Description { get; set; }
        public Nullable<short> PassingGrade { get; set; }
        public Nullable<short> NotifyDays { get; set; }
        public string NotifyEmail { get; set; }
        public Nullable<int> CompetencyStatusID { get; set; }
        public Nullable<short> RecurrenceQty { get; set; }
        public Nullable<int> UOMSchedulingRecurrenceID { get; set; }
        public Nullable<short> Failure_RecurrenceQty { get; set; }
        public Nullable<int> Failure_UOMSchedulingRecurrenceID { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
        public Nullable<int> TrainingTypeID { get; set; }
        public string TrainingType { get; set; }
    }
}
