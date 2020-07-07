using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityApi.Models.Commen
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmployeeCode { get; set; }
        public string Gender { get; set; }
        public int Designation { get; set; }
        public string DesignationName { get; set; }
        public int Department { get; set; }
        public string DepartmentName { get; set; }
  //      public string Dob { get; set; }
        public DateTime Dob { get; set; }
        public int Salary { get; set; }

    }
}
