using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSIWebTraining.Objects.Models
{
    public class MobileUser
    {
        public Nullable<int> EmployeeID { get; set; }
        public string Name { get; set; }

        public string EmployeeNumber { get; set; }
    }
}