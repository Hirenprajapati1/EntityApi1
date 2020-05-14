using System;
using System.Collections.Generic;

namespace EntityApi.Models.Entity
{
    public partial class TblEmp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public int? Salary { get; set; }
        public string Designation { get; set; }
    }
}
