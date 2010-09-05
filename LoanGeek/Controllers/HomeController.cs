using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanGeek.Models;

namespace LoanGeek.Controllers {
    public class HomeController : Controller {

        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoanData loanData) {
            loanData.CalculateTotalMonthlyPayment();
            ViewData["monthlyPayment"] = Math.Round(loanData.MonthlyPayment, 2);
            return View("Index", loanData);
        }
    }
}
