using System;
using System.Collections.Generic;

namespace EntityApi.Model1.Entity
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
