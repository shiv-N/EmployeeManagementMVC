using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBL
    {
        bool RegisterEmployee(RegisterEmpRequestModel employee);

        List<EmployeeDetailModel> GetAllEmployee();

        bool Delete(int EmpId);

        bool EditEmployee(RegisterEmpRequestModel employee);
    }
}
