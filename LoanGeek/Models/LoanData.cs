using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoanGeek.Models {
    public class LoanData {

        [Required(ErrorMessage = "Please enter your the total loan amount.")]
        [RegularExpression(@"[0-9,.]?", ErrorMessage = "Please enter a valid loan amount.")]
        public double Principal { get; set; }

        [Required(ErrorMessage = "Please enter the interest rate.")]
        [RegularExpression(@"[0-9,.]?", ErrorMessage = "Please enter a valid interest rate for your loan.")]
        public double InterestRate { get; set; }

        [Required(ErrorMessage = "Please enter the number of years of the loan.")]
        [RegularExpression(@"[0-9]?", ErrorMessage = "Please enter a valid loan term.")]
        public int LoanTerm { get; set; }

        [Required(ErrorMessage = "Please enter the property tax.")]
        [RegularExpression(@"[0-9,.]?", ErrorMessage = "Please enter a valid property tax amount..")]
        public double PropertyTaxPercent { get; set; }

        [Required(ErrorMessage = "Please enter your loan's PMI value.")]
        [RegularExpression(@"[0-9,.]?", ErrorMessage = "Please enter a valid PMI percentage.")]
        public double PmiPercent { get; set; }

        [Required(ErrorMessage = "Please enter your yearly HOA dues.")]
        [RegularExpression(@"[0-9,.]?", ErrorMessage = "Please enter a valid yearly HOA dues amount.")]
        public double HoaDuesYearly { get; set; }

        [Required(ErrorMessage = "Please enter your yearly insurance premium.")]
        [RegularExpression(@"[0-9,.]?", ErrorMessage = "Please enter a valid yearly home insurance premium.")]
        public double InsuranceYearly { get; set; }

        public double MonthlyInterestMultiplier { get; private set; }
        public int AmortizedMonths { get; private set; }
        public double InterestOnlyMonthly { get; private set; }
        public double PrincipalOnlyMonthly { get; private set; }
        public double MonthlyPayment { get; private set; }

        public double MonthlyPropertyTaxPayment { get; private set; }
        public double MonthlyPmiPayment { get; private set; }

        public LoanData(double principal, double interest, int term, double tax, double pmi, double hoa, double insurance) {
            Principal = principal;
            InterestRate = interest;
            LoanTerm = term;
            PropertyTaxPercent = tax;
            PmiPercent = pmi;
            HoaDuesYearly = hoa;
            InsuranceYearly = insurance;

            CalculateTotalMonthlyPayment();
        }

        public LoanData() {

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

        private double CalculatePropertyTax() {
            MonthlyPropertyTaxPayment = (Principal * (PropertyTaxPercent / 100)) / 12;
            return MonthlyPropertyTaxPayment;
        }

        private double CalculatePmi() {
            MonthlyPmiPayment = (Principal * (PmiPercent / 100)) / 12;
            return MonthlyPmiPayment;
        }

        private void CalculateTotalMonthlyPayment() {
            MonthlyPayment = CalculatePrincipalAndInterest();
            MonthlyPayment += CalculatePropertyTax();
            MonthlyPayment += CalculatePmi();
            MonthlyPayment += HoaDuesYearly / 12;
            MonthlyPayment += InsuranceYearly / 12;
        }
    }
}