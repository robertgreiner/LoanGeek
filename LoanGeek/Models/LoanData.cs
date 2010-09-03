using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanGeek.Models {
    public class LoanData {

        public double Principal { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public float PropertyTaxPercent { get; set; }
        public float PmiPercent { get; set; }
        public float HoaDuesYearly { get; set; }
        public float InsuranceYearly { get; set; }

        double MonthlyInterestMultiplier { get; set; }
        int AmortizedMonths { get; set; }

    }
}