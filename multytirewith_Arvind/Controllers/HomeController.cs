using BusinessAccessLayer;
using CommanLayer.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using multytirewith_Arvind.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace multytirewith_Arvind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BLEmployeeBusiness business = new BLEmployeeBusiness();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var emp = business.GetEmployees();
            return View(emp);
        }

        public IActionResult Create(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employees employee)
        {
         
            var result = business.CreateEmployee(employee);
            if(result)
            {
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in create employee !");
                return View(employee);

            }

            
        }



        public IActionResult Edit(int Id)
        {
            var emp = business.GetEmployeesById(Id);
            var model = new Employees()
            {
                Id = emp.Id,
                Name=emp.Name,
                Salary=emp.Salary,
                mobile=emp.mobile
            };

            
            return View(model);
        }
       

        [HttpPost]
        public IActionResult Edit(Employees employee)
        {
            var result = business.UpdateEmployee(employee);
            if (result)
            {
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in create employee !");
                return View(employee);

            }


        }




        public IActionResult Delete(int Id)
        {
            var result = business.DeleteEmployee(Id);
            if (result)
            {
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in create employee !");
                return View();

            }

        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
