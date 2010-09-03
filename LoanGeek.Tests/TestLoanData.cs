using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LoanGeek.Models;

namespace UnitTests {

    [TestFixture]
    public class TestLoanData {

        [Test]
        public void testRounding() {
            double num = 4.1245;
            num = Math.Round(num, 2);
            Assert.AreEqual(4.12, num);
        }

        [Test]
        public void TestTotalMonthlyPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 1.0, 600.00, 743.27);
            Assert.AreEqual(1623.90, Math.Round(loanData.MonthlyPayment, 2));
        }

        [Test]
        public void TestMonthlyInterestPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 1.0, 600.00, 743.27);
            Assert.AreEqual(687.50, Math.Round(loanData.InterestOnlyMonthly, 2));
        }

        [Test]
        public void TestMonthlyPrincipalPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 1.0, 600.00, 743.27);
            Assert.AreEqual(283.06, Math.Round(loanData.PrincipalOnlyMonthly, 2));
        }

        [Test]
        public void TestMonthlyPrincipalAndInterestPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 1.0, 600.00, 743.27);
            double principalAndInterest = loanData.InterestOnlyMonthly + loanData.PrincipalOnlyMonthly;
            Assert.AreEqual(969.30, Math.Round(principalAndInterest, 2));
        }

        [Test]
        public void TestMonthlyPropertyTaxPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 1.0, 600.00, 743.27);
            Assert.AreEqual(386.67, Math.Round(loanData.MonthlyPropertyTaxPayment, 2));
        }

        [Test]
        public void TestMonthlyPmiPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.5, 600.00, 743.27);
            Assert.AreEqual(83.33, Math.Round(loanData.MonthlyPmiPayment, 2));
        }

        [Test]
        public void TestMonthlyHoaPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 1.0, 600.00, 743.27);
            double monthlyHoa = loanData.HoaDuesYearly / 12;
            monthlyHoa = Math.Round(monthlyHoa, 2);
            Assert.AreEqual(50.00, monthlyHoa);
        }

        [Test]
        public void TestMonthlyInsurancePayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 1.0, 600.00, 743.27);
            double monthlyInsurance = loanData.InsuranceYearly / 12;
            monthlyInsurance = Math.Round(monthlyInsurance, 2);
            Assert.AreEqual(61.93, monthlyInsurance);
        }

    }
}
