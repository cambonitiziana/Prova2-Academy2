using System;

namespace BankAccount
{
    public class Movement
    {
        public decimal MovementAmount { get; set; }
        public DateTime MovementDate { get; set; }
        public bool isIncome { get; set; }

        public string IsIncomeString() 
        {
            
            if (isIncome)
            {
               return "Income";
            }
            else
            {
                return "Oulay";

            }
        }

    }
}