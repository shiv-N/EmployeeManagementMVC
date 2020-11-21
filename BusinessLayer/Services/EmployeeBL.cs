using BusinessLayer.Interfaces;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        private IEmployeeRL empService;

        public EmployeeBL(IEmployeeRL empService)
        {
            this.empService = empService;
        }

        public bool Delete(int EmpId)
        {
            try
            {
                return this.empService.Delete(EmpId);
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
                return this.empService.EditEmployee(employee);
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
                return this.empService.GetAllEmployee();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool RegisterEmployee(RegisterEmpRequestModel employee)
        {
            try
            {
                return this.empService.RegisterEmployee(employee);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
