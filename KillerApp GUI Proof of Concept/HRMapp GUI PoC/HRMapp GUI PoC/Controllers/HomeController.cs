using HRMapp_GUI_PoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMapp_GUI_PoC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var employees = new List<Employee>()
            {
                new Employee(){Name = "Dirk-Jan"},
                new Employee(){Name = "Dirk-Jan"},
                new Employee(){Name = "Dirk-Jan"},
                new Employee(){Name = "Dirk-Jan"},
                new Employee(){Name = "Dirk-Jan"},
                new Employee(){Name = "Dirk-Jan"},
                new Employee(){Name = "Dirk-Jan"},
                new Employee(){Name = "Dirk-Jan"},
            };

            var employs = new List<SelectListItem>();
            foreach (var employee in employees)
            {
                employs.Add(new SelectListItem() { Text = employee.Name, Value = "1" });
            }
            return View(employs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}