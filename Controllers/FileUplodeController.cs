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
using Microsoft.AspNetCore.Cors;

namespace EntityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class FileUplodeController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    //if (!Directory.Exists("Resources\\Files\\"))
                    //{
                    //    Directory.CreateDirectory("Resources\\Files\\");
                    //}

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        #region old method2
        //private static IWebHostEnvironment _enviroment;
        //public FileUplodeController(IWebHostEnvironment environment)
        //{
        //    _enviroment = environment;
        //}

        //public class FileUplodeAPI
        //{
        //    public IFormFile files { get; set; }
        //}
        //[HttpPost("FileUplode")]
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
        //        else
        //        {
        //            return "Failed";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message.ToString();
        //        //throw;
        //    }
        //}

        #endregion

        #region old method

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