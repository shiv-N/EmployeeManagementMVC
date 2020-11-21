using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class EmployeeDetailModel
    {
        public int EmpId { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int DepartmentId { get; set; }

        public string Department { get; set; }

        public string Amount { get; set; }

        public int SalaryId { get; set; }

        public DateTime StartDate { get; set; }

        public string Description { get; set; }
    }
}
