using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.MovementsEntities
{
   public  class CashMovement: Movement
    {
        public string Esecutor { get; set; }


        public CashMovement(decimal d, DateTime dt, bool b,  string esecutor)
        {
            isIncome = b;
            MovementAmount = d;
            MovementDate = dt;
            Esecutor = esecutor;
            
        }

       

        public override string ToString()
        {
            return $"Movement: CASH - {IsIncomeString()} - Amount: {MovementAmount} - Date: {MovementDate} - Esecutor: {Esecutor}";
        }
    }
}
