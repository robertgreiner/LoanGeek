using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoanGeek.Models {
    public class LoanData {

        [Required(ErrorMessage = "Please enter your the purchase price for your new home.")]
        public double PurchasePrice { get; set; }

        [Required(ErrorMessage = "Please enter the downpayment amount.")]
        public double DownPayment { get; set; }

        [Required(ErrorMessage = "Please enter the interest rate.")]
        public double InterestRate { get; set; }

        [Required(ErrorMessage = "Please enter the number of years of the loan.")]
        public int LoanTerm { get; set; }

        [Required(ErrorMessage = "Please enter the property tax.")]
        public double PropertyTaxPercent { get; set; }

        [Required(ErrorMessage = "Please enter your loan's PMI value.")]
        public double PmiPercent { get; set; }

        [Required(ErrorMessage = "Please enter your yearly HOA dues.")]
        public double HoaDuesYearly { get; set; }

        [Required(ErrorMessage = "Please enter your yearly insurance premium.")]
        public double InsuranceYearly { get; set; }

        public double Principal { get; set; }

        public double MonthlyInterestMultiplier { get; private set; }
        public int AmortizedMonths { get; private set; }
        public double InterestOnlyMonthly { get; private set; }
        public double PrincipalOnlyMonthly { get; private set; }
        public double MonthlyPayment { get; private set; }

        public double MonthlyPropertyTaxPayment { get; private set; }
        public double MonthlyPmiPayment { get; private set; }

        public LoanData(double purchasePrice, double downPayment, double interest, int term, double tax, double pmi, double hoa, double insurance) {
            PurchasePrice = purchasePrice;
            DownPayment = downPayment;
            InterestRate = interest;
            LoanTerm = term;
            PropertyTaxPercent = tax;
            PmiPercent = pmi;
            HoaDuesYearly = hoa;
            InsuranceYearly = insurance;

            CalculateTotalMonthlyPayment();
        }

        public LoanData() {
            PurchasePrice = 200000;
            DownPayment = 7.5;
            InterestRate = 4.5;
            LoanTerm = 30;
            PropertyTaxPercent = 3.0;
            PmiPercent = 1.0;
            HoaDuesYearly = 500.00;
            InsuranceYearly = 1000.00;
        }

        /**
         * How to Calculate Loan Amortization Schedules/Tables by Hand
         * http://www.hughchou.org/calc/formula.html
         * 
         * P = Principal
         * I = Annual interest rate
         * L = Loan Term (years)
         * 
         * J = Monthly interest in decimal form. 
         * J = I / (12 * 100)
         * 
         * N = Number of months over which the loan is amortized.
         * N = L * 12
         * 
         * M = Monthly Payment
         * 
         * M = P * ( J / ( 1 - (1 + J)^-N ) )
         */
        private double CalculatePrincipalAndInterest() {
            double principalAndInterest = 0.0;

            MonthlyInterestMultiplier = InterestRate / (12 * 100);
            AmortizedMonths = LoanTerm * 12;

            double amortizedExpression = (1 - (Math.Pow((1 + MonthlyInterestMultiplier), -AmortizedMonths)));
            principalAndInterest = Principal * (MonthlyInterestMultiplier / amortizedExpression);

            InterestOnlyMonthly = Principal * MonthlyInterestMultiplier;
            PrincipalOnlyMonthly = principalAndInterest - InterestOnlyMonthly;

            return principalAndInterest;
        }

        //Property tax is based on the appraisal value of the home.  Usually, this is the same as the purchase price.
        private double CalculatePropertyTax() {
            MonthlyPropertyTaxPayment = (PurchasePrice * (PropertyTaxPercent / 100)) / 12;
            return MonthlyPropertyTaxPayment;
        }

        private double CalculatePmi() {
            MonthlyPmiPayment = (Principal * (PmiPercent / 100)) / 12;
            return MonthlyPmiPayment;
        }

        private void CalculatePrincipal() {
            Principal = PurchasePrice - (PurchasePrice * (DownPayment / 100));
        }

        public void CalculateTotalMonthlyPayment() {
            CalculatePrincipal();
            MonthlyPayment = CalculatePrincipalAndInterest();
            MonthlyPayment += CalculatePropertyTax();
            MonthlyPayment += CalculatePmi();
            MonthlyPayment += HoaDuesYearly / 12;
            MonthlyPayment += InsuranceYearly / 12;
        }
    }
}