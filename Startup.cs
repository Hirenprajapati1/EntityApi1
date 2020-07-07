using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EntityApi.Repository;
using EntityApi.Models.Commen;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.CodeAnalysis.Emit;
using EntityApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http.Features;

namespace EntityApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });


            services.AddControllers();
            var appSettingsSection = Configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingsSection);

            //JWT Authentication
            var appSetting = appSettingsSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSetting.Key);

            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
             });
            

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
               
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });


            app.UseRouting();
            app.UseCors();


            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("could not found any thing");
            });

                    }
    }
}













//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using EntityApi.Repository;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;

//namespace EntityApi
//{
//    public class Startup
//    {
//        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddCors(options =>
//            {
//                options.AddPolicy("AllowMyOrigin",
//                builder => builder.WithOrigins("http://localhost:4200")
//                .AllowAnyMethod()
//                .AllowAnyHeader());
//            });


//            services.AddControllers();
//            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }


//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseCors();



//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}
