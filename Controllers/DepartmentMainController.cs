using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityApi.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityApi.Models.Commen;

namespace EntityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowMyOrigin")]
    public class DepartmentMainController : ControllerBase
    {
        //private readonly IDepartmentRepository _departmentRepository;

        //public DepartmentMainController(IDepartmentRepository departmentRepository)
        //{
        //    _departmentRepository = departmentRepository;
        //}

        //[HttpGet("GetDesignation")]
        //public List<Models.Commen.TblDesignation> GetDesignations()
        //{
        //    return _departmentRepository.GetDesignation();
        //}

        //[HttpGet("GetDepartment")]
        //public List<Models.Commen.TblDepartment> GetDepartments()
        //{
        //    return _employeeRepository.GetDepartment();
        //}

    }
}