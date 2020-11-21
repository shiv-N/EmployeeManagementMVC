using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRL
    {
        bool RegisterEmployee(RegisterEmpRequestModel employee);

        List<EmployeeDetailModel> GetAllEmployee();

        bool Delete(int EmpId);

        bool EditEmployee(RegisterEmpRequestModel employee);
    }
}
