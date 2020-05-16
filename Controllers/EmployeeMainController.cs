using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityApi.Models.Commen;
using EntityApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace EntityApi.Controllers
{
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

        [HttpGet("GetEmployee")]
        public List<Models.Commen.TblEmployee> GetEmployees()
        {
            //**** move this below code to dependency injection ***
            //_employeeRepository = employeeRepository;

            return _employeeRepository.GetEmployees();
        }

  

        [HttpPost("SaveEmployee")]
        public int SaveEmployee([FromBody] TblEmployee emp1)
        {
            return _employeeRepository.SaveEmployee(emp1);
        }

        [HttpPost("EditEmployee")]
        public int EditEmployee([FromBody] TblEmployee emp)
        {
            return _employeeRepository.EditEmployee(emp);
        }
        
        [HttpDelete("DeleteEmployee/{id}")]
        public int DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        //************
        //Designation
        //************

        [HttpGet("GetDesignation")]
        public List<Models.Commen.TblDesignation> GetDesignations()
        {
            return _employeeRepository.GetDesignation();
        }

        [HttpPost("AddDesignation")]
        public int AddDesignation([FromBody] TblDesignation des1)
        {
            return _employeeRepository.AddDesignation(des1);
        }

        [HttpPost("EditDesignation")]
        public int EditDesignation([FromBody] TblDesignation des)
        {
            return _employeeRepository.EditDesignation(des);
        }

        [HttpDelete("DeleteDesignation/{id}")]
        public int DeleteDesignation(int id)
        {
            return _employeeRepository.DeleteDesignation(id);
        }


        //************
        //Department
        //************

        [HttpGet("GetDepartment")]
        public List<Models.Commen.TblDepartment> GetDepartments()
        {
            return _employeeRepository.GetDepartment();
        }


        [HttpPost("AddDepartment")]
        public int AddDepartment([FromBody] TblDepartment dept1)
        {
            return _employeeRepository.AddDepartment(dept1);
        }

        [HttpPost("EditDepartment")]
        public int EditDepartment([FromBody] TblDepartment dept)
        {
            return _employeeRepository.EditDepartment(dept);
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public int DeleteDepartment(int id)
        {
            return _employeeRepository.DeleteDepartment(id);
        }


    }
}