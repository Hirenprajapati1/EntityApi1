using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityApi.Model1.Entity
{
    public partial class TblEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmployeeCode { get; set; }
        public string Gender { get; set; }
        public int Designation { get; set; }
        public int Department { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yy}")] 
        public DateTime Dob { get; set; }
        public int Salary { get; set; }
        public virtual TblDepartment DepartmentNavigation { get; set; }
        public virtual TblDesignation DesignationNavigation { get; set; }
    }
}
