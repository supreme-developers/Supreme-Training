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
    
    public partial class CompetencyJobRole
    {
        public int ID { get; set; }
        public Nullable<int> CompDefHeaderID { get; set; }
        public Nullable<int> JobRoleID { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreateDateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
    }
}
