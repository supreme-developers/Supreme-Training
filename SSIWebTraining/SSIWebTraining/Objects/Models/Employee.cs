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
    
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInit { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ResidentCity { get; set; }
        public string ResidentState { get; set; }
        public string ZipCode { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public string TraverseDepCode { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<short> UseDefaultTimeOffDef { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> DepartmentOverRode { get; set; }
        public string PhoneHome { get; set; }
        public string ContactWorkPhone { get; set; }
        public string ContactRelation { get; set; }
        public Nullable<int> JobTitleID { get; set; }
        public string SSN { get; set; }
        public string ContactHomePhone { get; set; }
        public string EmergencyContact { get; set; }
        public Nullable<System.DateTime> ServiceHireDate { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    }
}
