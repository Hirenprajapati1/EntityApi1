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
        public int AddDesignation(Models.Commen.TblDesignation DesignationModel);
        public int EditDesignation(Models.Commen.TblDesignation EditDes);
        public int DeleteDesignation(int Id);
        
        
        public List<Models.Commen.TblDepartment> GetDepartment();
        public int AddDepartment(Models.Commen.TblDepartment DepartmentModel);
        public int EditDepartment(Models.Commen.TblDepartment EditDept);
        public int DeleteDepartment(int Id)

;

    }
}
