using EntityApi.Model1.Entity;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Employee

        public List<Models.Commen.Employee> GetEmployees()
        {
            List <Models.Commen.Employee>employees = new List<Models.Commen.Employee>();
            try
            {
                using(var dBContext = new EmployeeDatabaseContext())
                {
                    //GetEmployee
                    Models.Commen.Employee employee1;
                    foreach (var emp in dBContext.TblEmployee.ToList())
                    {
                        employee1 = new Models.Commen.Employee();
                        employee1.Id = emp.Id;
                        employee1.Name = emp.Name;
                        employee1.Email = emp.Email;
                        employee1.EmployeeCode = emp.EmployeeCode;
                        employee1.Gender = emp.Gender;
                        employee1.Designation = emp.Designation;
                        employee1.DesignationName = dBContext.TblDesignation.FirstOrDefault(x => x.DesignationId == emp.Designation).DesignationName;

                        //if (emp.Designation != null)
                        //{
                        //employee1.DesignationName = dBContext.TblDesignation.FirstOrDefault(x => x.DesignationId == emp.Designation).DesignationName;
                        //}

                        employee1.Department = emp.Department;

                        //if (emp.Department != null)
                        //{
                            employee1.DepartmentName = dBContext.TblDepartment.FirstOrDefault(x => x.DepartmentId == emp.Department).DepartmentName;
                        //}

                        //employee1.Dob =(emp.Dob).ToString("dd-MMM-yyyy");
                        employee1.Dob = emp.Dob;
                        employee1.Salary = emp.Salary;
                     
                    
                        employees.Add(employee1);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return employees;
        }



        //Get Emp By ID
        //public Models.Commen.Employee getemployeebyid(int id)
        //{
        //    try
        //    {
        //        Models.Commen.Employee employee1;
        //        using (var dbcontext = new HirenEmployeeContext())
        //        {
        //            dbcontext.TblEmployee emp;
        //            //var db = dbcontext.TblEmployee.SingleOrDefault(x => x.id == id);
        //            //var emp in dBContext.TblEmployee

        //                employee1 = new Models.Commen.Employee();
        //                employee1.Id = emp.id;
        //                employee1.Name = emp.name;
        //                employee1.Email = emp.email;
        //                employee1.EmployeeCode = emp.employeecode;
        //                employee1.Gender = emp.gender;
        //                employee1.Designation = emp.designation;
        //                employee1.Department = emp.department;
        //                employee1.Dob = emp.dob;
        //                employee1.Salary = emp.salary;

        //                employeedata.add(employee1);

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.message);
        //        //throw;
        //    }
        //    return employeedata;
        //}

        //aaa Start

        public Models.Commen.Employee GetEmployeeById(int id)
        {
            Models.Commen.Employee EmployeeData = new Models.Commen.Employee();
            try
            {
                using (var dBContext = new EmployeeDatabaseContext())
                {
                    //GetEmployee
                    var emp = dBContext.TblEmployee.Where(x => x.Id == id).SingleOrDefault();
                    if (emp != null)
                    {
                        EmployeeData.Id = emp.Id;
                        EmployeeData.Name = emp.Name;
                        EmployeeData.Email = emp.Email;
                        EmployeeData.EmployeeCode = emp.EmployeeCode;
                        EmployeeData.Gender = emp.Gender;
                        EmployeeData.Designation = emp.Designation;
                        EmployeeData.Department = emp.Department;
                        EmployeeData.Dob = emp.Dob;
                        //EmployeeData.Dob = (emp.Dob).ToString("yyyy-MM-dd");
                        EmployeeData.Salary = emp.Salary;


                    }
                    return EmployeeData;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        //public static int CalculateYourAge(DateTime Dob)
        //{
        //    DateTime Now = DateTime.Now;
        //    int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
        //    DateTime PastYearDate = Dob.AddYears(Years);
        //    int Months = 0;
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        if (PastYearDate.AddMonths(i) == Now)
        //        {
        //            Months = i;
        //            break;
        //        }
        //        else if (PastYearDate.AddMonths(i) >= Now)
        //        {
        //            Months = i - 1;
        //            break;
        //        }
        //    }
        //    int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
        //    //int Hours = Now.Subtract(PastYearDate).Hours;
        //    //int Minutes = Now.Subtract(PastYearDate).Minutes;
        //    //int Seconds = Now.Subtract(PastYearDate).Seconds;
        //    //return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) ",
        //    //Years, Months, Days);
        //    return Years;
        //}

        public int SaveEmployee(Models.Commen.Employee EmployeeModel, string EmployeeCode, DateTime Dob)
        {
            int returnVal = 0;
            List<Models.Commen.Employee> employees = new List<Models.Commen.Employee>();
            try
            {
                using (var dBContext=new EmployeeDatabaseContext())
                {
                    //GetEmployee
                    Models.Commen.Employee employee1;
                    foreach (var emp in dBContext.TblEmployee.ToList())
                    {
                        employee1 = new Models.Commen.Employee();
                        employee1.Email = emp.Email;
                        employee1.EmployeeCode = emp.EmployeeCode;
                        employees.Add(employee1);
                    }
                    Model1.Entity.TblEmployee employeeEntity;
                    //Add Employee
                    if (EmployeeModel.Id == 0)
                    {
                        employeeEntity = new TblEmployee();
                        employeeEntity.Name = EmployeeModel.Name;
                        employeeEntity.Email = EmployeeModel.Email;
                        employeeEntity.EmployeeCode = EmployeeModel.EmployeeCode;
                        employeeEntity.Gender = EmployeeModel.Gender;
                        employeeEntity.Designation = EmployeeModel.Designation;
                        employeeEntity.Department = EmployeeModel.Department;
                        employeeEntity.Dob = Convert.ToDateTime(EmployeeModel.Dob);
                        employeeEntity.Salary = EmployeeModel.Salary;
                        dBContext.TblEmployee.Add(employeeEntity);
                        EmployeeCode = employeeEntity.EmployeeCode;
                        Dob = Convert.ToDateTime(EmployeeModel.Dob);
                    }
                    //DateTime Now = DateTime.Now;
                    //int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                    //DateTime PastYearDate = Dob.AddYears(Years);
                    //int Months = 0;
                    //for (int i = 1; i <= 12; i++)
                    //{
                    //    if (PastYearDate.AddMonths(i) == Now)
                    //    {
                    //        Months = i;
                    //        break;
                    //    }
                    //    else if (PastYearDate.AddMonths(i) >= Now)
                    //    {
                    //        Months = i - 1;
                    //        break;
                    //    }
                    //}
              
                    int age = 0;
                    age = DateTime.Now.Year - Dob.Year;
                    if (DateTime.Now.DayOfYear < (Dob.DayOfYear) + 1)
                    {
                        age = age - 1;
                      
                    }


                    bool empcodexist = employees.Any(x => x.EmployeeCode == EmployeeCode);
                    //if((empcodexist == true) && (age < 21))
                    //{
                    //    returnVal = -3;
                    //}
                     if(empcodexist == true)
                    {
                        returnVal = -1;
                    }
                    else if(age < 21)
                    {
                        returnVal = -2;
                    }
                    else
                    { 
                    returnVal = dBContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        public int EditEmployee(Models.Commen.Employee EditEmp, string EmployeeCode,int Id, DateTime Dob,string Email)
        {
            List<Models.Commen.Employee> employees = new List<Models.Commen.Employee>();
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new EmployeeDatabaseContext())
                {
                    //GetEmployee
                    Models.Commen.Employee employee1;
                    foreach (var emp in dBContext1.TblEmployee.ToList())
                    {
                        employee1 = new Models.Commen.Employee();
                        employee1.Id = emp.Id;
                        employee1.Email = emp.Email;
                        employee1.EmployeeCode = emp.EmployeeCode;
                        employees.Add(employee1);
                    }

                    Model1.Entity.TblEmployee employeeEntity = new TblEmployee();
                    employeeEntity = dBContext1.TblEmployee.FirstOrDefault(x => x.Id == EditEmp.Id);
                        if (employeeEntity != null)
                        {
                            //employeeEntity = new TblEmployee();
                            employeeEntity.Id = EditEmp.Id;
                            employeeEntity.Name = EditEmp.Name;
                            employeeEntity.Email = EditEmp.Email;
                            employeeEntity.EmployeeCode = EditEmp.EmployeeCode;
                            employeeEntity.Gender = EditEmp.Gender;
                            employeeEntity.Designation = EditEmp.Designation;
                            employeeEntity.Department = EditEmp.Department;
                            employeeEntity.Dob = Convert.ToDateTime((EditEmp.Dob).ToString()); 
                            employeeEntity.Salary = EditEmp.Salary;
                            dBContext1.TblEmployee.Update(employeeEntity);
                            Id = employeeEntity.Id;
                            EmployeeCode = employeeEntity.EmployeeCode;
                            Email = employeeEntity.Email;
                            Dob = Convert.ToDateTime(EditEmp.Dob);
                    }

                    //DateTime Now = DateTime.Now;
                    //int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                    //DateTime PastYearDate = Dob.AddYears(Years);
                    //int Months = 0;
                    //for (int i = 1; i <= 12; i++)
                    //{
                    //    if (PastYearDate.AddMonths(i) == Now)
                    //    {
                    //        Months = i;
                    //        break;
                    //    }
                    //    else if (PastYearDate.AddMonths(i) > Now)
                    //    {
                    //        Months = i - 1;
                    //        break;
                    //    }
                    //}
                    int age = 0;
                    age = DateTime.Now.Year - Dob.Year;
                    if (DateTime.Now.DayOfYear < (Dob.DayOfYear) + 1)
                    {
                        age = age - 1;
                    }
       
                    bool empcodexist = employees.Any(x => x.EmployeeCode == EmployeeCode);
                    bool empcodexist1 = employees.Any(x => (x.Id == Id) && (x.EmployeeCode == EmployeeCode));
                    //bool empemilExist = employees.Any(x => x.Email == Email);
                    //bool empemilExist1 = employees.Any(x => (x.Id == Id) && (x.Email == Email));
                    //bool idcodeemali = employees.Any(x => (x.Id == Id) && (x.Email == Email) && (x.EmployeeCode == EmployeeCode));
                    if (age < 21)
                    {
                        returnVal = -3;
                    }
                    //else if (idcodeemali == true)
                    //{
                    //    returnVal = dBContext1.SaveChanges();
                    //}
                    else if (empcodexist1 == true)
                    {
                        returnVal = dBContext1.SaveChanges();
                    }   
                    else if(empcodexist == true )
                    {
                        returnVal = -1;
                    }
                    else 
                    { 
                    returnVal = dBContext1.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        public int DeleteEmployee(int Id)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new EmployeeDatabaseContext())
                {
                    Model1.Entity.TblEmployee employeeEntity = new TblEmployee();
                    Models.Commen.Employee DeleteEmp = new Models.Commen.Employee();
                    employeeEntity = dBContext1.TblEmployee.FirstOrDefault(x => x.Id == Id);
                    if (employeeEntity != null)
                    {
                        //employeeEntity = new TblEmployee();
                        //employeeEntity.Id = DeleteEmp.Id;
                        //employeeEntity.Name = DeleteEmp.Name;
                        //employeeEntity.Email = DeleteEmp.Email;
                        //employeeEntity.EmployeeCode = EditEmp.EmployeeCode;
                        //employeeEntity.Gender = EditEmp.Gender;
                        //employeeEntity.Designation = EditEmp.Designation;
                        //employeeEntity.Department = EditEmp.Department;
                        //employeeEntity.Dob = EditEmp.Dob;
                        //employeeEntity.Salary = EditEmp.Salary;
                        dBContext1.TblEmployee.Remove(employeeEntity);
                    }
                    returnVal = dBContext1.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        #endregion

        #region Designation

        //************************
        //Designation
        //************************


        public Models.Commen.Designation GetDesignationById(int id)
        {
            Models.Commen.Designation DesignationData = new Models.Commen.Designation();
            try
            {
                using (var dBContext = new EmployeeDatabaseContext())
                {
                    //GetEmployee
                    var deg = dBContext.TblDesignation.Where(x => x.DesignationId == id).SingleOrDefault();
                    if (deg != null)
                    {
                        DesignationData.DesignationId = deg.DesignationId;
                        DesignationData.DesignationName = deg.DesignationName;

                    }
                    return DesignationData;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public List<Models.Commen.Designation> GetDesignation()
        {
            List<Models.Commen.Designation> designations = new List<Models.Commen.Designation>();
            try
            {
                using (var dBContext = new EmployeeDatabaseContext())
                {
                    //GetDesignations
                    Models.Commen.Designation designation1;
                    foreach (var des in dBContext.TblDesignation)
                    {
                        designation1 = new Models.Commen.Designation();
                        designation1.DesignationId = des.DesignationId;
                        designation1.DesignationName = des.DesignationName;
                        designations.Add(designation1);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return designations;

        }


        public int AddDesignation(Models.Commen.Designation DesignationModel , string DesignationName)
        {
            int returnVal = 0;
            try
            {
                List<Models.Commen.Designation> designations = new List<Models.Commen.Designation>();
                using (var dBContext = new EmployeeDatabaseContext())
                {

                    //GetDesignations
                    Models.Commen.Designation designation1;
                    foreach (var des in dBContext.TblDesignation)
                    {
                        designation1 = new Models.Commen.Designation();
                        designation1.DesignationName = des.DesignationName;
                        designations.Add(designation1);

                    }


                    Model1.Entity.TblDesignation designationEntity;
                    //Add Designation
                    if (DesignationModel.DesignationId == 0)
                    {
                        designationEntity = new TblDesignation();
                        designationEntity.DesignationName = DesignationModel.DesignationName;
                        dBContext.TblDesignation.Add(designationEntity);
                        DesignationName = designationEntity.DesignationName;
                    }
                    bool degtexist = designations.Any(x => x.DesignationName == DesignationName);
                    if (degtexist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        returnVal = dBContext.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;

        }



        public int EditDesignation(Models.Commen.Designation EditDes, string DesignationName ,int DesignationId )
        {
            List<Models.Commen.Designation> designations = new List<Models.Commen.Designation>();

            int returnVal = 0;
            try
            {
                using (var dBContext1 = new EmployeeDatabaseContext())
                {
                    //GetDesignations
                    Models.Commen.Designation designation1;
                    foreach (var des in dBContext1.TblDesignation)
                    {
                        designation1 = new Models.Commen.Designation();
                        designation1.DesignationId = des.DesignationId;
                        designation1.DesignationName = des.DesignationName;
                        designations.Add(designation1);

                    }


                    Model1.Entity.TblDesignation designationEntity = new TblDesignation();
                    designationEntity = dBContext1.TblDesignation.FirstOrDefault(x => x.DesignationId == EditDes.DesignationId);
                    if (designationEntity != null)
                    {
                        designationEntity.DesignationId = EditDes.DesignationId;
                        designationEntity.DesignationName = EditDes.DesignationName;
                        dBContext1.TblDesignation.Update(designationEntity);
                        DesignationId = designationEntity.DesignationId;
                        DesignationName = designationEntity.DesignationName;
                    }
                 
                    bool degtexist1 = designations.Any(x => (x.DesignationId == DesignationId) && (x.DesignationName == DesignationName));
                    bool degtexist = designations.Any(x => x.DesignationName == DesignationName);
                    if (degtexist1 == true)
                    {
                        returnVal = dBContext1.SaveChanges();
                    }
                    else if (degtexist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        returnVal = dBContext1.SaveChanges();
                    }


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        public int DeleteDesignation(int Id)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new EmployeeDatabaseContext())
                {
                    Model1.Entity.TblDesignation designationEntity = new TblDesignation();
                    Models.Commen.Designation DeleteDes = new Models.Commen.Designation();
                    designationEntity = dBContext1.TblDesignation.FirstOrDefault(x => x.DesignationId == Id);
                    if (designationEntity != null)
                    {
                        dBContext1.TblDesignation.Remove(designationEntity);
                    }
                    returnVal = dBContext1.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        #endregion 

        #region Department

        //************************
        //Department
        //************************



        public Models.Commen.Department GetDepartmentById(int id)
        {
            Models.Commen.Department departments = new Models.Commen.Department();
            try
            {
                using (var dBContext = new EmployeeDatabaseContext())
                {
                    //GetEmployee
                    var dept = dBContext.TblDepartment.Where(x => x.DepartmentId == id).SingleOrDefault();
                    if(dept != null)
                    {
                        departments.DepartmentId = dept.DepartmentId;
                        departments.DepartmentName = dept.DepartmentName;
            
                    }
                    return departments;


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
                    }


        public List<Models.Commen.Department> GetDepartment()
        {
            List<Models.Commen.Department> departments = new List<Models.Commen.Department>();
            try
            {
                using (var dBContext = new EmployeeDatabaseContext())
                {
                    //GetDepartment
                    Models.Commen.Department department1;
                    foreach (var dept in dBContext.TblDepartment)
                    {
                        department1 = new Models.Commen.Department();
                        department1.DepartmentId = dept.DepartmentId;
                        department1.DepartmentName = dept.DepartmentName;
                        departments.Add(department1);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return departments;

        }


        public int AddDepartment(Models.Commen.Department DepartmentModel ,string DepartmentName)
        {

            List<Models.Commen.Department> departments = new List<Models.Commen.Department>();

            int returnVal = 0;
            try
            {
                using (var dBContext = new EmployeeDatabaseContext())
                {
                    //GetDepartment
                    Models.Commen.Department department1;
                    foreach (var dept in dBContext.TblDepartment)
                    {
                        department1 = new Models.Commen.Department();
                        department1.DepartmentName = dept.DepartmentName;
                        departments.Add(department1);

                    }

                    Model1.Entity.TblDepartment departmentEntity;
                    //Add Designation
                    if (DepartmentModel.DepartmentId == 0)
                    {
                        departmentEntity = new TblDepartment();
                        departmentEntity.DepartmentName = DepartmentModel.DepartmentName;
                        dBContext.TblDepartment.Add(departmentEntity);
                        DepartmentName = departmentEntity.DepartmentName;
                    }

                   bool deptexist = departments.Any(x => x.DepartmentName == DepartmentName);
                    if(deptexist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    { 
                     returnVal = dBContext.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;

        }

        public int EditDepartment(Models.Commen.Department EditDept , string DepartmentName,int DepartmentId)
        {
            List<Models.Commen.Department> departments = new List<Models.Commen.Department>();
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new EmployeeDatabaseContext())
                {
                    //GetDepartment
                    Models.Commen.Department department1;
                    foreach (var dept in dBContext1.TblDepartment)
                    {
                        department1 = new Models.Commen.Department();
                        department1.DepartmentId = dept.DepartmentId;
                        department1.DepartmentName = dept.DepartmentName;
                        departments.Add(department1);
                    }

                    Model1.Entity.TblDepartment departmentEntity = new TblDepartment();
                    departmentEntity = dBContext1.TblDepartment.FirstOrDefault(x => x.DepartmentId == EditDept.DepartmentId);
                    if (departmentEntity != null)
                    {
                        departmentEntity.DepartmentId = EditDept.DepartmentId;
                        departmentEntity.DepartmentName = EditDept.DepartmentName;
                        dBContext1.TblDepartment.Update(departmentEntity);
                        DepartmentName = departmentEntity.DepartmentName;
                        DepartmentId = departmentEntity.DepartmentId;
                    }

                    bool deptexist = departments.Any(x => x.DepartmentName == DepartmentName);
                    bool deptexist1 = departments.Any(x => (x.DepartmentId == DepartmentId)  && (x.DepartmentName == DepartmentName));

                    if ((deptexist1 == true))
                    {
                        returnVal = dBContext1.SaveChanges();
                    }
                    else if(deptexist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        returnVal = dBContext1.SaveChanges();
                    }

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        public int DeleteDepartment(int Id)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new EmployeeDatabaseContext())
                {
                    Model1.Entity.TblDepartment departmentEntity = new TblDepartment();
                    Models.Commen.Department DeleteDept = new Models.Commen.Department();
                    departmentEntity = dBContext1.TblDepartment.FirstOrDefault(x => x.DepartmentId == Id);
                    if (departmentEntity != null)
                    {
                        dBContext1.TblDepartment.Remove(departmentEntity);
                    }
                    returnVal = dBContext1.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;
        }

        #endregion
    }
}
