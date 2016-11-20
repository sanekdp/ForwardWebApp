using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveForward(FormCollection data)
        {
            return RedirectToAction("Error", new { error = "Ошибка предсталения" });
            //return RedirectToAction("Index");
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

        public ActionResult Error(string error)
        {
            ViewBag.Message = error;
            return View();
        }

        public JsonResult Employees(string query)
        {
            var dataEmp = new List<Employee>
            {

                new Employee { Name = "Стрижикурка Роман Михайлович", Email = "rstrizhikurka@badm.biz" },
                new Employee { Name = "Мазурец Алексей Александрович", Email = "amazurets@badm.biz" },
                new Employee { Name = "Сергей Валентинович Каплунов", Email = "skaplunov@badm.biz" },
                new Employee { Name = "Назарёк Игорь", Email = "inazarek@badm.biz" }
            };

            //var result = Json(dataEmp.Select(s => string.Format("{0}\n{1}", s.Name, s.Email)), JsonRequestBehavior.DenyGet);
            var result = Json(dataEmp, JsonRequestBehavior.DenyGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }
    }
    
}