using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanGeek.Models {
    public class LoanData {

        public double Principal { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public double PropertyTaxPercent { get; set; }
        public double PmiPercent { get; set; }
        public double HoaDuesYearly { get; set; }
        public double InsuranceYearly { get; set; }

        public double MonthlyInterestMultiplier { get; private set; }
        public int AmortizedMonths { get; private set; }
        public double MonthlyPayment { get; private set; }

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
            double principleAndInterest = 0.0;

            MonthlyInterestMultiplier = InterestRate / (12 * 100);
            AmortizedMonths = LoanTerm * 12;

            double amortizedExpression = (1 - (Math.Pow((1 + MonthlyInterestMultiplier), -AmortizedMonths)));
            principleAndInterest = Principal * (MonthlyInterestMultiplier / amortizedExpression);

            return principleAndInterest;
        }

        private double CalculatePropertyTax() {
            double propertyTax = (Principal * (InterestRate / 100)) / 12;
            return propertyTax;
        }

        private double CalculatePmi() {
            double pmi = (Principal * (PmiPercent / 100)) / 12;
            return pmi;
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