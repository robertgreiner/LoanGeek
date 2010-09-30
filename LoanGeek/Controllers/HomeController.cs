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
            if (ModelState.IsValid) {
                loanData.CalculateTotalMonthlyPayment();
                ViewData["MonthlyPayment"] = Math.Round(loanData.MonthlyPayment, 2);
                ViewData["Principal"] = Math.Round(loanData.PrincipalOnlyMonthly, 2);
                ViewData["Interest"] = Math.Round(loanData.InterestOnlyMonthly, 2);
                ViewData["PropertyTax"] = Math.Round(loanData.MonthlyPropertyTaxPayment, 2);
                ViewData["Pmi"] = Math.Round(loanData.MonthlyPmiPayment, 2);
                ViewData["Hoa"] = Math.Round(loanData.HoaDuesYearly / 12, 2);
                ViewData["Insurance"] = Math.Round(loanData.InsuranceYearly / 12, 2);
                return View("Index", loanData);
            } else {
                return View();
            }
        }
    }
}
