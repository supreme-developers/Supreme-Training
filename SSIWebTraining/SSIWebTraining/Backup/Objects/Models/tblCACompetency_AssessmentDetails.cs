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
    using System.Collections.Generic;
    
    public partial class tblCACompetency_AssessmentDetails
    {
        public int CompetencyAssessment_DetailID { get; set; }
        public Nullable<int> CompetencyAssessmentID { get; set; }
        public Nullable<int> CompetencyTaskID { get; set; }
        public Nullable<int> TaskRating { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreateDateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
    
        public virtual tblCACompetency_AssessmentHeader tblCACompetency_AssessmentHeader { get; set; }
        public virtual CompetencyTask tblCACompetency_DefinitionTasks { get; set; }
    }
}
