using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Models;
using FirstApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
       
        public ViewResult Index()
        {
            var employees =  _employeeRepository.GetEmployees();
            return View(employees);

        }

        public ViewResult Details(int ?  Id)
        {
            Employee model = _employeeRepository.GetEmployee(Id ?? 1);
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = model,
                PageTitle = "Employee Detail"
            };
           
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                Employee NewEmployee = _employeeRepository.Add(employee);

                return RedirectToAction("details", new { id = NewEmployee.Id });
            }

            return View();
        }
    }
}