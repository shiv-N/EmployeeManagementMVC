using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{

    public class EmployeeRL : IEmployeeRL
    {
        private CompanyDbContext db = new CompanyDbContext();

        public bool Delete(int EmpId)
        {
            try
            {
                Employee employee = db.Employees.Where(x => x.EmpId == EmpId).FirstOrDefault();
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                }
                int result = db.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool EditEmployee(RegisterEmpRequestModel employee)
        {
            try
            {
                Employee validEmp = db.Employees.Where(x => x.EmpId == employee.EmpId).FirstOrDefault();
                if(validEmp != null)
                {
                    int departmentId = db.Departments.Where(x => x.DeptName == employee.Department).Select(x => x.DeptId).FirstOrDefault();
                    validEmp.EmpId = employee.EmpId;
                    validEmp.Name = employee.Name;
                    validEmp.Gender = employee.Gender;
                    validEmp.DepartmentId = departmentId;
                    validEmp.SalaryId = Convert.ToInt32(employee.SalaryId);
                    validEmp.StartDate = employee.StartDate;
                    validEmp.Description = employee.Description;
                    //Employee UpdatedEmp = new Employee()
                    //{
                    //    EmpId = employee.EmpId,
                    //    Name = employee.Name,
                    //    Gender = employee.Gender,
                    //    DepartmentId = employee.DepartmentId,
                    //    SalaryId = employee.SalaryId,
                    //    StartDate = employee.StartDate,
                    //    Description = employee.Description
                    //};
                    //db.Entry<Employee>(UpdatedEmp).State = System.Data.Entity.EntityState.Modified;
                    int result = db.SaveChanges();
                    if(result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<EmployeeDetailModel> GetAllEmployee()
        {
            try
            {
                List<EmployeeDetailModel> list = (from e in db.Employees
                                                  join d in db.Departments on e.DepartmentId equals d.DeptId
                                                  join s in db.Salaries on e.SalaryId equals s.SalaryId
                                                  select new EmployeeDetailModel
                                                  {
                                                      EmpId = e.EmpId,
                                                      Name = e.Name,
                                                      Gender = e.Gender,
                                                      DepartmentId = d.DeptId,
                                                      Department = d.DeptName,
                                                      SalaryId = s.SalaryId,
                                                      Amount = s.Amount,
                                                      StartDate = e.StartDate,
                                                      Description = e.Description
                                                  }).ToList<EmployeeDetailModel>();

                return list;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public string getResponce(int id)
        {
            //var Department = new List<Department> { new Department { DeptName = "Computer" } };
            //Department.ForEach(s => db.Departments.Add(s));
            //int result1 = db.SaveChanges();

            //Department model = db.Departments.Where(x => x.DeptName == "Computer").FirstOrDefault();

            //var Salary = new List<Salary> { new Salary {  Amount = "50000" } };
            //Salary.ForEach(e => db.Salaries.Add(e));
            //int result3 = db.SaveChanges();
            //Salary salary = db.Salaries.Where(x => x.Amount == "50000").FirstOrDefault();


            var Employee = new List<Employee>
            { new Employee { Name = "Shiv",Gender = "Male", DepartmentId=1,StartDate = DateTime.Now,SalaryId=1,
            Description = "Test 3"} };
            Employee.ForEach(e => db.Employees.Add(e));
            int result2 = db.SaveChanges();

            Employee model1 = db.Employees.Where(x => x.Name == "Shiv" && x.Gender == "Male").FirstOrDefault();

            

            return " 2:" + result2.ToString();
        }

        public bool RegisterEmployee(RegisterEmpRequestModel employee)
        {
            try
            {
                Employee validEmployee = db.Employees.Where(x => x.Name == employee.Name && x.Gender == employee.Gender).FirstOrDefault();
                if (validEmployee == null)
                {
                    int departmentId = db.Departments.Where(x => x.DeptName == employee.Department).Select(x => x.DeptId).FirstOrDefault();
                    Employee newEmployee = new Employee()
                    {
                        Name = employee.Name,
                        Gender = employee.Gender,
                        DepartmentId = departmentId,
                        SalaryId = Convert.ToInt32(employee.SalaryId),
                        StartDate = employee.StartDate,
                        Description = employee.Description
                    };
                    Employee returnData = db.Employees.Add(newEmployee);
                }
                int result = db.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
