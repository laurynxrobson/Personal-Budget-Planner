using System;

namespace PersonalBudgetPlanner
{
    class Program
    {
        public static double[] expenses = new double[6];
        // Expenditure Object
        public static HomeLoan expenditure = new(expenses[0], expenses[1], expenses[2], expenses[3], expenses[4], expenses[5]);
        static void Main(string[] args)
        {
            Console.WriteLine("*** WELCOME ***");
            // Asking User Input
            PromptingUser();
            Console.WriteLine("***************************************************************************************");
            // Allowing the user to choose between renting accommodation or buying property using an if statement
            RentOrBuy();
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

                // Estimated Monthly Expenditures
                // Groceries
                Console.Write("Enter Groceries: ");
                expenditure.SetGroceries(Double.Parse(Console.ReadLine()));

                // Water and Lights
                Console.Write("Enter Water and Lights: ");
                expenditure.SetWaterLights(Double.Parse(Console.ReadLine()));

                // Travel costs (including petrol)
                Console.Write("Enter Travel Costs (including petrol): ");
                expenditure.SetTravel(Double.Parse(Console.ReadLine()));

                // Cell phone and telephone
                Console.Write("Enter Cell phone and Telephone: ");
                expenditure.SetPhone(Double.Parse(Console.ReadLine()));

                // Other expenses
                Console.Write("Enter Any other Expenses: ");
                expenditure.SetOther(Double.Parse(Console.ReadLine()));


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
        // Rent or Buy Method
        public static void RentOrBuy()
        {
            Console.WriteLine("\nSelect: \n(0) -- Renting \n(1) -- Buying");
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
            }
            catch
            {
                Console.WriteLine("Please select an option either 0 and 1.");
                goto restart;
            }
        }
        // Rent Method
        public static void Rent()
        {
            Console.WriteLine("***************************************************************************************");

            // If the user selects rent, the user is able to enter the monthly rental amount
            Console.Write("Enter Monthly Rental Amount: ");
            double rentalAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Rental Amount: " + rentalAmount);
        }

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
            double a = (prinicpal) * (1 + (i * n));
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


        // Net Income Method
        public static void DisplayNetIncome()
        {
            Console.WriteLine("***************************************************************************************");
            double netIncome = expenditure.GetGross() - expenditure.Expenditures();
            Console.WriteLine("Available monthly money after deductions: " + netIncome);
        }
    }
}
