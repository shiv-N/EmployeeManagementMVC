using BusinessLayer.Interfaces;
using CommonLayer.Request;
using CommonLayer.Response;
using EmployeeManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeBL empService;

        public EmployeeController(IEmployeeBL empService)
        {
            this.empService = empService;
    }

        // GET: Employee
        public ActionResult Register()
        {
            var sessionStorage = this.Session["LoginMail"] as string;
            if (sessionStorage != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(RegisterEmpRequestModel model)
        {
            var sessionStorage = this.Session["LoginMail"] as string;
            if (sessionStorage != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult EditEmployee(RegisterEmpRequestModel employee)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = this.empService.EditEmployee(employee);
            }
            return RedirectToAction("EmployeeList");
        }

        [HttpPost]
        public ActionResult RegisterEmployee(RegisterEmpRequestModel employee)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = this.empService.RegisterEmployee(employee);
            }
            ModelState.Clear();

            if(result == true)
            {
                return RedirectToAction("EmployeeList");
            }
            return View("Register",employee);
        }

        public ActionResult EmployeeList()
        {
            var sessionStorage = this.Session["LoginMail"] as string;
            if (sessionStorage != null)
            {
                List<EmployeeDetailModel> list = this.empService.GetAllEmployee();
                return View(list);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int EmpId)
        {
            bool result = this.empService.Delete(EmpId);
            return RedirectToAction("EmployeeList");
        }

    }
}
