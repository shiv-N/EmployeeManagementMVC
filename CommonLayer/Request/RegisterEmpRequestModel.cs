﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Request
{
    public class RegisterEmpRequestModel
    {
        public int EmpId { get; set; }

        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Required")]
        public string SalaryId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime StartDate { get; set; }

        public string Description { get; set; }
    }
}
