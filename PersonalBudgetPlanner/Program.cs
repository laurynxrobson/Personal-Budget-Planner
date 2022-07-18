using System;
using System.Collections.Generic;

namespace PersonalBudgetPlanner
{
    public class Delegate
    {
        public delegate void Notification();
        public static void Exceeded()
        {
            Console.WriteLine("Your expense exceed 75% of your income.");
        }
        public static void NotExceeded()
        {
            Console.WriteLine("Your expense do not exceed 75% of your income.");
        }
    }
    class Program
    {
        // Expenditure Object
        public static HomeLoan expenditure = new();
        // Car Cost Object
        public static Vehicle carCost = new();
        // Generic collection to store the expenses
        public static List<double> costs = new();
        // Deleagate object
        public static Delegate Notify = new();


        static void Main(string[] args)
        {
            Console.WriteLine("*** WELCOME ***");
            // Asking User Input
            PromptingUser();
            Console.WriteLine("***************************************************************************************");
            // Allowing the user to choose between renting accommodation or buying property using an if statement
            PurchaseOptions();
            Console.WriteLine("***************************************************************************************");
        }

        // Prompting User Method
        public static void PromptingUser()
        {
            try
            {
                // Gross Monthly Income before deductions
                Console.Write("Enter Gross Monthly Income Before Deductions: ");
                expenditure.SetGross(Double.Parse(Console.ReadLine()));

                // Estimated Monthly Tax Deducted
                Console.Write("Enter Estimated Monthly Tax Deducted: ");
                expenditure.SetTax(Double.Parse(Console.ReadLine()));
                costs.Add(expenditure.GetTax());

                // Estimated Monthly Expenditures
                // Groceries
                Console.Write("Enter Groceries: ");
                expenditure.SetGroceries(Double.Parse(Console.ReadLine()));
                costs.Add(expenditure.GetGroceries());

                // Water and Lights
                Console.Write("Enter Water and Lights: ");
                expenditure.SetWaterLights(Double.Parse(Console.ReadLine()));
                costs.Add(expenditure.GetWaterLights());


                // Travel costs (including petrol)
                Console.Write("Enter Travel Costs (including petrol): ");
                expenditure.SetTravel(Double.Parse(Console.ReadLine()));
                costs.Add(expenditure.GetTravel());

                // Cell phone and telephone
                Console.Write("Enter Cell phone and Telephone: ");
                expenditure.SetPhone(Double.Parse(Console.ReadLine()));
                // costName.Add("Cell Phone and Telephone");
                costs.Add(expenditure.GetPhone());

                // Other expenses
                Console.Write("Enter Any other Expenses: ");
                expenditure.SetOther(Double.Parse(Console.ReadLine()));
                // costName.Add("Other Expense");
                costs.Add(expenditure.GetOther());


                // Testing 
                Console.WriteLine("\nGross Monthly Income Before Deductions: " + expenditure.GetGross());
                Console.WriteLine("Estimated Monthly Tax Deducted: " + expenditure.GetTax());
                Console.WriteLine("Total Expenses: " + expenditure.Expenditures());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // Rent accomodation, Buy accommodatio or buy  a vehicle Method
        public static void PurchaseOptions()
        {
            Console.WriteLine("\nSelect: \n(0) -- Renting \n(1) -- Buying \n(2) -- Vehicle");
        restart:
            try
            {

                int option = int.Parse(Console.ReadLine());

                if (option == 0)
                {
                    Rent();
                }
                else if (option == 1)
                {
                    Buying();
                }
                else if (option == 2)
                {
                    BuyVehicle();
                }
            }
            catch
            {
                Console.WriteLine("Please select an option either 0, 1, 2.");
                goto restart;
            }
        }
        /*** RENT ***/
        // Rent Method
        public static void Rent()
        {
            Console.WriteLine("***************************************************************************************");

            // If the user selects rent, the user is able to enter the monthly rental amount
            Console.Write("Enter Monthly Rental Amount: ");
            double rentalAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Rental Amount: " + rentalAmount);
        }

        /***RENT END***/

        /***BUYING PROPERTY***/
        // Buying Method
        public static void Buying()
        {
            Console.WriteLine("***************************************************************************************");

            // If the user selects buy property, the user will be asked to enter the following values
            // Purchase price of the property
            Console.Write("Enter the purchase price of the property: ");
            double propertyPrice = double.Parse(Console.ReadLine());

            // Total deposit
            Console.Write("Enter the total deposit: ");
            double totalDeposit = double.Parse(Console.ReadLine());

            // Interest rate (percentage)
            Console.Write("Enter the interest rate (percentage): ");
            double interestRate = double.Parse(Console.ReadLine());

        // Number of months to repay the loan (between 240 and 360)
        tryAgain:
            Console.Write("Enter the number of months to repay (between 240 - 360): ");
            double repayMonths = double.Parse(Console.ReadLine());
            if (repayMonths < 240 || repayMonths > 360)
            {
                Console.WriteLine("Invalid entry. Please try again.");
                goto tryAgain;
            }

            // Calculate the monthly home loan repayment
            double prinicpal = (propertyPrice - totalDeposit);
            double i = interestRate / 100;
            double n = repayMonths / 12;
            double a = prinicpal * (1 + (i * n));
            expenditure.SetLoanRepay(Math.Round((a / repayMonths), 2));


            Console.WriteLine("\nThe monthly home loan repayment: " + expenditure.GetLoanRepay());
            LoanValidation();

        }

        // Home Loan Validation Methd
        public static void LoanValidation()
        {
            Console.WriteLine("***************************************************************************************");

            // If the monthly home loan repayment is more than a third of the user's gross monthly income, alert the user that apporval of the home loan is unlikely
            double oneThirdOfIncome = (expenditure.GetGross() * 0.33);

            if (expenditure.GetLoanRepay() > oneThirdOfIncome)
            {
                Console.WriteLine("Home Loan is unlikely.");
                DisplayNetIncome();
            }
            else
            {
                Console.WriteLine("Home Loan is approved.");
                DisplayNetIncome();
            }
        }
        /*** BUYING PROPERTRY END ***/

        // Net Income Method
        public static void DisplayNetIncome()
        {
            Console.WriteLine("***************************************************************************************");
            double netIncome = expenditure.GetGross() - expenditure.Expenditures();
            Console.WriteLine("Available monthly money after deductions: " + netIncome);
            BuyVehicle();

        }

        /*** BUY VEHICLE ***/
        // Buy Vehicle
        public static void BuyVehicle()
        {
            Console.WriteLine("***************************************************************************************");

            Console.WriteLine("Enter Model and Make: ");
            carCost.SetModelNMake(Console.ReadLine());

            Console.WriteLine("Enter Purchase Price: ");
            carCost.SetPrice(Double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter Total Deposit: ");
            carCost.SetDeposit(Double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter Interest rate (percentage): ");
            carCost.SetInterest(Double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter Estimated insurance premium: ");
            carCost.SetInsurance(Double.Parse(Console.ReadLine()));
            //costName.Add("Insurance premium");
            costs.Add(carCost.GetInsurance());
            VehicleCost();
        }

        // Method to calculate the monthly car cost
        public static void VehicleCost()
        {
            Console.WriteLine("***************************************************************************************");
            double prinicpal = (carCost.GetPrice() - carCost.GetDeposit());
            double i = carCost.GetInterest() / 100;
            double n = 60;
            double a = (prinicpal) * (1 + (i * n));
            carCost.SetTotalVehicle(Math.Round((a / 60), 2) + carCost.GetInsurance() + expenditure.GetLoanRepay());
            Console.WriteLine("The total monthly cost of buying the car is: " + carCost.GetTotalVehicle());
            CarLoanValidation();
        }
        // Notify using delegate the user when the total expenses exceed 75% of their income, including loan repayments.
        public static void CarLoanValidation()
        {
            Console.WriteLine("***************************************************************************************");

            double limit = (expenditure.GetGross() * 0.75);
            // Instantiation
            Delegate.Notification D1 = new(Delegate.Exceeded);
            Delegate.Notification D2 = new(Delegate.NotExceeded);
            if (expenditure.GetTotal() > limit)
            {
                D1();
                DisplayExpenses();
            }
            else
            {
                D2();
                DisplayExpenses();
            }
        }
        /*** BUYING VEHICLE END ***/
        // Display the expenses to the user in descending order by value.  
        public static void DisplayExpenses()
        {
            Console.WriteLine("***************************************************************************************");

            //costName.Sort();
            costs.Sort();
            foreach (double d in costs)
                //foreach(string s in costName)
                //Console.WriteLine(s.ToString() + ": " + d.ToString());
                Console.WriteLine(d.ToString());
        }

    }


}