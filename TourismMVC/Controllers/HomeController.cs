using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismMVC.Models;

namespace TourismMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var members = new List<GroupMember>
            {
                new GroupMember { StudentId = "20021750", FullName = "Marcos Yukihiro Vieira Yamashita" },
                new GroupMember { StudentId = "20028065", FullName = "GURJOT SINGH" },
                new GroupMember { StudentId = "20032744", FullName = "Aven Matthew MAJELLANO" }
            };

            return View(members);
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