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
    
    public partial class EmployeeQualification
    {
        public int QualificationID { get; set; }
        public string Qualification { get; set; }
        public string Acronym { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDateTime { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
    }
}
