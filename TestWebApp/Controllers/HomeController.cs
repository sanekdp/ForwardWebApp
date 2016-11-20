using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
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
            TempData["error"] = "Ошибка предсталения";
            return RedirectToAction("Error");
            //return RedirectToAction("Index");
        }

        private List<Employee> FindAllUser()
        {
            var domains = new[]
            {
                "vdp-dc02.office.badm.com",
                "vdp-uvc-dc02.ukrvetcom.dp.ua"
            };
            var result = new List<Employee>();
            foreach (var domain in domains)
            {
                using (var ctx = new PrincipalContext(ContextType.Domain, domain))
                {
                    var filter = new UserPrincipal(ctx) { Enabled = true };

                    var srch = new PrincipalSearcher(filter);

                    result.AddRange(srch.FindAll().Cast<UserPrincipal>().Where(u => !string.IsNullOrEmpty(u.EmailAddress) && u.EmployeeId?.Length < 7).Select(s => new Employee { Name = s.Name, Email = s.EmailAddress, EmployeeId = int.Parse(s.EmployeeId) }));
                }
            }
            return result;
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
            ViewBag.Message = TempData["error"];
            TempData["error"] = null;
            return View();
        }

        public JsonResult Employees(string query)
        {
            //var dataEmp = new List<Employee>
            //{

            //    new Employee { Name = "Стрижикурка Роман Михайлович", Email = "rstrizhikurka@badm.biz" },
            //    new Employee { Name = "Мазурец Алексей Александрович", Email = "amazurets@badm.biz" },
            //    new Employee { Name = "Сергей Валентинович Каплунов", Email = "skaplunov@badm.biz" },
            //    new Employee { Name = "Назарёк Игорь", Email = "inazarek@badm.biz" }
            //};

            //var result = Json(dataEmp.Select(s => string.Format("{0}\n{1}", s.Name, s.Email)), JsonRequestBehavior.DenyGet);
            var result = Json(FindAllUser(), JsonRequestBehavior.DenyGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }
    }
    
}