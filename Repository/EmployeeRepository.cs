using EntityApi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Models.Commen.TblEmployee> GetEmployees()
        {
            List <Models.Commen.TblEmployee>employees = new List<Models.Commen.TblEmployee>();
            try
            {
                using(var dBContext = new HirenEmployeeContext())
                {
                    //GetEmployee
                    Models.Commen.TblEmployee employee1;
                    foreach(var emp in dBContext.TblEmployee)
                    {
                        employee1 = new Models.Commen.TblEmployee();
                        employee1.Id = emp.Id;
                        employee1.Name = emp.Name;
                        employee1.Email = emp.Email;
                        employee1.EmployeeCode = emp.EmployeeCode;
                        employee1.Gender = emp.Gender;
                        employee1.Designation = emp.Designation;
                        employee1.Department = emp.Department;
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

        public List<Models.Commen.TblDesignation> GetDesignation()
        {
            List<Models.Commen.TblDesignation> designations = new List<Models.Commen.TblDesignation>();
            try
            {
                using (var dBContext = new HirenEmployeeContext())
                {
                    //GetEmployee
                    Models.Commen.TblDesignation designation1;
                    foreach (var des in dBContext.TblDesignation)
                    {
                        designation1 = new Models.Commen.TblDesignation();
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
        public List<Models.Commen.TblDepartment> GetDepartment()
        {
            List<Models.Commen.TblDepartment> departments = new List<Models.Commen.TblDepartment>();
            try
            {
                using (var dBContext = new HirenEmployeeContext())
                {
                    //GetEmployee
                    Models.Commen.TblDepartment department1;
                    foreach (var dept in dBContext.TblDepartment)
                    {
                        department1 = new Models.Commen.TblDepartment();
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
        public int SaveEmployee(Models.Commen.TblEmployee EmployeeModel)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext=new HirenEmployeeContext())
                {
                    Models.Entity.TblEmployee employeeEntity;
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
                        employeeEntity.Dob = EmployeeModel.Dob;
                        employeeEntity.Salary = EmployeeModel.Salary;
                        dBContext.TblEmployee.Add(employeeEntity);
                    }
                    returnVal = dBContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return returnVal;

        }

        public int EditEmployee(Models.Commen.TblEmployee EditEmp)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new HirenEmployeeContext())
                {
                    Models.Entity.TblEmployee employeeEntity = new TblEmployee();

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
                            employeeEntity.Dob = EditEmp.Dob;
                            employeeEntity.Salary = EditEmp.Salary;
                            dBContext1.TblEmployee.Update(employeeEntity);
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

        public int DeleteEmployee(int Id)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext1 = new HirenEmployeeContext())
                {
                    Models.Entity.TblEmployee employeeEntity = new TblEmployee();
                    Models.Commen.TblEmployee DeleteEmp = new Models.Commen.TblEmployee();
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

    }
}
