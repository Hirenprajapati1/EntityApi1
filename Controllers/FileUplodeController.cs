using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityApi.Model1.Entity;
using EntityApi.Models.Commen;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Hosting;

namespace EntityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUplodeController : ControllerBase
    {
        //private static IWebHostEnvironment _enviroment;
        //public FileUplodeController(IWebHostEnvironment environment)
        //{
        //    _enviroment = environment;
        //}

        //public class FileUplodeAPI
        //{
        //     public IFormFile files { get; set; }
        //}
        //[HttpPost]
        //public async Task<string> Post(FileUplodeAPI objFile)
        //{
        //    try
        //    {
        //        if (objFile.files.Length > 0)
        //        {
        //            if (!Directory.Exists(_enviroment.WebRootPath + "\\Uplode\\"))
        //            {
        //                Directory.CreateDirectory(_enviroment.WebRootPath + "\\Uplode\\");
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(_enviroment.WebRootPath + "\\Uplode\\" + objFile.files.FileName))
        //            {
        //                objFile.files.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "\\Uplode\\" + objFile.files.FileName;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        #region old

        //[HttpPost("UplodeImage")]
        //public HttpResponseMessage UplodeImage()
        //{
        //    string fileName = null;
        //    var httpRequest = System.Web.HttpContext.Current.Request;
        //    var PostedFile = httpRequest.Files["image"];
        //    fileName = new string(Path.GetFileNameWithoutExtension(PostedFile.FileName).Take(10).ToArray()).Replace("", "-");
        //    fileName = fileName + DateTime.Now.ToString("yymmmssfff") + Path.GetExtension(PostedFile.filename);
        //    var filePath = HttpContent.Server.MapPath("~/Image/" + fileName);
        //    PostedFile.saveAs(filePath);

        //    //Save to Database
        //    using (EmployeeDatabaseContext db = new EmployeeDatabaseContext())
        //    {
        //        TblUser file = new TblUser()
        //        {
        //            Name = httpRequest["Name"],
        //            FileName = fileName
        //        };
        //        db.TblUser.Add(file);
        //        db.SaveChanges();

        //    }

        //    return Request.CreateResponse(HttpStatusCode,Created);

        //    }
            #endregion
    }
}