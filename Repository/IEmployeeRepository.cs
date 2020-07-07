using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityApi.Repository
{
    public interface IEmployeeRepository
    {
        public List<Models.Commen.Employee> GetEmployees();
        public Models.Commen.Employee GetEmployeeById(int id);

        //public int SaveEmployee(Models.Commen.Employee EmployeeModel);
        public int SaveEmployee(Models.Commen.Employee EmployeeModel, string EmployeeCode, DateTime Dob);
        //public int EditEmployee(Models.Commen.Employee EditEmp);
        public int EditEmployee(Models.Commen.Employee EditEmp, string EmployeeCode, int Id, DateTime Dob, string Email);
        public int DeleteEmployee(int id);

        public Models.Commen.Designation GetDesignationById(int id);
        public List<Models.Commen.Designation> GetDesignation();
        //public int AddDesignation(Models.Commen.Designation DesignationModel);
        public int AddDesignation(Models.Commen.Designation DesignationModel, string DesignationName);
        //public int EditDesignation(Models.Commen.Designation EditDes);
        public int EditDesignation(Models.Commen.Designation EditDes, string DesignationName, int DesignationId);
        public int DeleteDesignation(int Id);


        public Models.Commen.Department GetDepartmentById(int id);
        public List<Models.Commen.Department> GetDepartment();
        //public int AddDepartment(Models.Commen.Department DepartmentModel);
        public int AddDepartment(Models.Commen.Department DepartmentModel, string DepartmentName);
        //public int EditDepartment(Models.Commen.Department EditDept);
        //public int EditDepartment(Models.Commen.Department EditDept, string DepartmentName);
        public int EditDepartment(Models.Commen.Department EditDept, string DepartmentName, int DepartmentId);

        public int DeleteDepartment(int Id)

;

    }
}
