using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityApi.Models.Commen;
using EntityApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace EntityApi.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    //[Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class EmployeeMainController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeMainController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #region Employee

        [HttpGet("GetEmployee")]
        public List<Models.Commen.Employee> GetEmployees()
        {
            //**** move this below code to dependency injection ***
            //_employeeRepository = employeeRepository;

            return _employeeRepository.GetEmployees();
        }

        [HttpGet("GetEmployeeById/{id}")]
        public Models.Commen.Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }


        [HttpPost("SaveEmployee")]
        public int SaveEmployee([FromBody] Employee emp1, string EmployeeCode, DateTime Dob)
        {
            return _employeeRepository.SaveEmployee(emp1, EmployeeCode, Dob);
        }

        [HttpPost("EditEmployee/{id}")]
        public int EditEmployee([FromBody] Employee emp, string EmployeeCode, int Id, DateTime Dob, string Email)
        {
            return _employeeRepository.EditEmployee(emp, EmployeeCode, Id,  Dob,  Email);
        }
        
        [HttpDelete("DeleteEmployee/{id}")]
        public int DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }


        #endregion

        #region Designation

        //************
        //Designation
        //************

        [HttpGet("GetDesignationById/{id}")]
        public Models.Commen.Designation GetDesignationById(int id)
        {
            return _employeeRepository.GetDesignationById(id);
        }


        [HttpGet("GetDesignation")]
        public List<Models.Commen.Designation> GetDesignations()
        {
            return _employeeRepository.GetDesignation();
        }

        [HttpPost("AddDesignation")]
        public int AddDesignation([FromBody] Designation des1 , string DesignationName)
        {
            return _employeeRepository.AddDesignation(des1, DesignationName);
        }

        [HttpPost("EditDesignation/{id}")]
        public int EditDesignation([FromBody] Designation des, string DesignationName, int DesignationId)
        {
            return _employeeRepository.EditDesignation(des, DesignationName, DesignationId);
        }

        [HttpDelete("DeleteDesignation/{id}")]
        public int DeleteDesignation(int id)
        {
            return _employeeRepository.DeleteDesignation(id);
        }

        #endregion

        #region Department

        //************
        //Department
        //************

        [HttpGet("GetDepartmentById/{id}")]
        public Models.Commen.Department GetDepartmentById(int id)
        {
            return _employeeRepository.GetDepartmentById(id);
        }


        [HttpGet("GetDepartment")]
        public List<Models.Commen.Department> GetDepartments()
        {
            return _employeeRepository.GetDepartment();
        }


        [HttpPost("AddDepartment")]
        public int AddDepartment([FromBody] Department dept1, string DepartmentName)
        {
            return _employeeRepository.AddDepartment(dept1, DepartmentName);
        }

        [HttpPost("EditDepartment/{id}")]
        public int EditDepartment([FromBody] Department dept, string DepartmentName, int DepartmentId)
        {
            return _employeeRepository.EditDepartment(dept, DepartmentName, DepartmentId);
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public int DeleteDepartment(int id)
        {
            return _employeeRepository.DeleteDepartment(id);
        }

        #endregion
    }
}