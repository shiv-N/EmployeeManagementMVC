using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using EmployeeManagementMVC.Controllers;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace EmployeeManagementMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeBL, EmployeeBL>();
            container.RegisterType<IEmployeeRL, EmployeeRL>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}