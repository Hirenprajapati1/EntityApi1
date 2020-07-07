using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityApi.Models.Commen;
using EntityApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EntityApi.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes =Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowMyOrigin")]
    //[Route("api/[controller]")]
    //[ApiController]

    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }  
        [HttpPost]
        public IActionResult Post([FromBody] Admindata Model)
        {
            var user = _authenticateService.Authenticate(Model.UserName, Model.Password);


            //if(user != null)
            //{
            //    return Ok(user);
            //}
            //else
            //{
            //    return null;
            //}
            if (user == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });

            }
            else
            {
                return Ok(user);
            }
        }



        //private IConfiguration _config;

        //public AuthenticationController(IConfiguration config)
        //{
        //    _config = config;
        //}

        //[HttpGet]
        //public IActionResult Login(string username ,string pass)
        //{
        //    AdminModel login = new AdminModel();
        //}
    }
}