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
    
    public partial class SSIRentEntities : DbContext
    {
        public SSIRentEntities()
            : base("name=SSIRentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EmployeeJobRole> EmployeeJobRoles { get; set; }
        public virtual DbSet<EmployeeJobTitle> EmployeeJobTitles { get; set; }
        public virtual DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        public virtual DbSet<SchedulingRecurrenceUOM> SchedulingRecurrenceUOMs { get; set; }
    
        public virtual int sp_Sys_Users()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Sys_Users");
        }
    
        public virtual int sp_SYS_GetUserInfo(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_SYS_GetUserInfo", userIDParameter);
        }
    
        public virtual ObjectResult<User> sp_SYS_GetUserCredentials(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("sp_SYS_GetUserCredentials", userNameParameter, passwordParameter);
        }
    }
}
