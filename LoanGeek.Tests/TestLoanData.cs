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
            double num = 4.1245 / 22;
            num = Math.Round(num, 2);
            Assert.AreEqual(0.19d, num);
        }

        [Test]
        public void TestTotalMonthlyPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.8, 600.00, 743.27);
            Assert.AreEqual(1674.57, Math.Round(loanData.MonthlyPayment, 2));
        }

        [Test]
        public void TestMonthlyInterestPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.8, 600.00, 743.27);
            Assert.AreEqual(687.50d, Math.Round(loanData.InterestOnlyMonthly, 2));
        }

        [Test]
        public void TestMonthlyPrincipalPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.8, 600.00, 743.27);
            double principalMonthly = Math.Round(loanData.PrincipalOnlyMonthly, 2);
            Assert.AreEqual(281.80d, principalMonthly);
        }

        [Test]
        public void TestMonthlyPrincipalAndInterestPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.8, 600.00, 743.27);
            double principalAndInterest = loanData.InterestOnlyMonthly + loanData.PrincipalOnlyMonthly;
            Assert.AreEqual(969.30d, Math.Round(principalAndInterest, 2));
        }

        [Test]
        public void TestMonthlyPropertyTaxPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.8, 600.00, 743.27);
            Assert.AreEqual(460.00, Math.Round(loanData.MonthlyPropertyTaxPayment, 2));
        }

        [Test]
        public void TestMonthlyPmiPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.8, 600.00, 743.27);
            Assert.AreEqual(133.33d, Math.Round(loanData.MonthlyPmiPayment, 2));
        }

        [Test]
        public void TestMonthlyHoaPayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.8, 600.00, 743.27);
            double monthlyHoa = loanData.HoaDuesYearly / 12;
            monthlyHoa = Math.Round(monthlyHoa, 2);
            Assert.AreEqual(50.00d, monthlyHoa);
        }

        [Test]
        public void TestMonthlyInsurancePayment() {
            LoanData loanData = new LoanData(200000.00, 4.125, 30, 2.76, 0.8, 600.00, 743.27);
            double monthlyInsurance = loanData.InsuranceYearly / 12;
            monthlyInsurance = Math.Round(monthlyInsurance);
            Assert.AreEqual(62.00d, monthlyInsurance);
        }

    }
}
