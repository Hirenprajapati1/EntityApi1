using System;
using System.Collections.Generic;

namespace EntityApi.Model1.Entity
{
    public partial class TblDesignation
    {
        public TblDesignation()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int DesignationId { get; set; }
        public string DesignationName { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
