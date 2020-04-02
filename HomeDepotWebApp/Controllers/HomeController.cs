using HomeDepotWebApp.Models;
using HomeDepotWebApp.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDepotWebApp.Controllers
{
    public class HomeController : Controller
    {
        private HomeDepotContext _context = new HomeDepotContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            var customers = _context.Customers.Where(c => c is CustomerWithLogin
            && (c as CustomerWithLogin).Username.Equals(Username)
            && (c as CustomerWithLogin).Password.Equals(Password)).ToList();

            if (customers.Count() > 0)
            {
                return View(customers[0]);
            }
            else
            {
                return View();
            }
        }
    }
}