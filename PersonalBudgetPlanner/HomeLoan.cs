using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetPlanner
{
    class HomeLoan : Expense
    {
        // Declare variables with access specifiers
        private double groceries;
        private double waterLights;
        private double travel;
        private double phone;
        private double other;
        private double total;
        private double tax;
        private double gross;
        private double loanRepay;


        // GETTERS AND SETTERS

        //Groceries
        public double GetGroceries()
        {
            return groceries;
        }
        public void SetGroceries(double groceries)
        {
            this.groceries = groceries;
        }
        // Water and Lights
        public double GetWaterLights()
        {
            return waterLights;
        }
        public void SetWaterLights(double waterLights)
        {
            this.waterLights = waterLights;
        }

        // Travel
        public double GetTravel()
        {
            return travel;
        }
        public void SetTravel(double travel)
        {
            this.travel = travel;
        }
        // Phone 
        public double GetPhone()
        {
            return phone;
        }
        public void SetPhone(double phone)
        {
            this.phone = phone;
        }
        // Other
        public double GetOther()
        {
            return other;
        }
        public void SetOther(double other)
        {
            this.other = other;
        }

        //Total
        public double GetTotal()
        {
            return total;
        }
        public void SetTotal(double total)
        {
            this.total = total;
        }

        //Tax
        public double GetTax()
        {
            return tax;
        }
        public void SetTax(double tax)
        {
            this.tax = tax;
        }

        //Gross
        public double GetGross()
        {
            return gross;
        }
        public void SetGross(double gross)
        {
            this.gross = gross;
        }

        // Loan Repayment
        public double GetLoanRepay()
        {
            return loanRepay;
        }
        public void SetLoanRepay(double loanRepay)
        {
            this.loanRepay = loanRepay;
        }
        //Constructor with parameters
        public HomeLoan(double gro, double wnl, double tra, double pho, double oth, double taxIncome)
        {
            groceries = gro;
            waterLights = wnl;
            travel = tra;
            phone = pho;
            other = oth;
            tax = taxIncome;
        }

        //Override Methods
        public override double Expenditures()
        {
            total = (groceries + waterLights + travel + phone + other + tax);
            return total;
        }
    }
}
