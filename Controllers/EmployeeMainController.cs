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

        [HttpGet("GetDesignation")]
        public List<Models.Commen.TblDesignation> GetDesignations()
        {
            return _employeeRepository.GetDesignation();
        }

        [HttpGet("GetDepartment")]
        public List<Models.Commen.TblDepartment> GetDepartments()
        {
            return _employeeRepository.GetDepartment();
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


    }
}