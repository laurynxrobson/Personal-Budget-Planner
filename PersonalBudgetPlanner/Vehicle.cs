using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetPlanner
{
    class Vehicle
    {
        private string modelNMake;
        private double price;
        private double deposit;
        private double interest;
        private double insurance;
        private double totalVehicle;

        // Model and Make
        public string GetModelNMake()
        {
            return modelNMake;
        }
        public void SetModelNMake(string modelNMake)
        {
            this.modelNMake = modelNMake;
        }

        // Price 
        public double GetPrice()
        {
            return price;
        }
        public void SetPrice(double price)
        {
            this.price = price;
        }

        // Deposit
        public double GetDeposit()
        {
            return deposit;
        }
        public void SetDeposit(double deposit)
        {
            this.deposit = deposit;
        }

        // Interest
        public double GetInterest()
        {
            return interest;
        }
        public void SetInterest(double interest)
        {
            this.interest = interest;
        }

        // Insurance
        public double GetInsurance()
        {
            return insurance;
        }
        public void SetInsurance(double insurance)
        {
            this.insurance = insurance;
        }

        // Vehicle 
        public double GetTotalVehicle()
        {
            return totalVehicle;
        }
        public void SetTotalVehicle(double totalVehicle)
        {
            this.totalVehicle = totalVehicle;
        }

    }
}
