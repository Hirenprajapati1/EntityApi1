using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityApi.Repository
{
    public interface IEmployeeRepository
    {
        public List<Models.Commen.TblEmployee> GetEmployees();
        public int SaveEmployee(Models.Commen.TblEmployee EmployeeModel);
        public int EditEmployee(Models.Commen.TblEmployee EditEmp);
        public int DeleteEmployee(int id);
        public List<Models.Commen.TblDesignation> GetDesignation();
        public List<Models.Commen.TblDepartment> GetDepartment();

    }
}
