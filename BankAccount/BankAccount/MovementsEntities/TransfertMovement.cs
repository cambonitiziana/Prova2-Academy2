using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.MovementsEntities
{
    public class TransfertMovement: Movement
    {
        public string OriginBank { get; set; }
        public string  DestinationBank { get; set; }


        public TransfertMovement(decimal ma, DateTime md, bool b, string ob, string db)
            {
            isIncome = b;
            MovementAmount = ma;
            MovementDate = md;
            OriginBank = ob;
            DestinationBank = db;
        }
        public override string ToString()
        {
            return $"Movement: TRANSFER - {IsIncomeString()} - Amount: {MovementAmount} - Date: {MovementDate} - Origin Bank: {OriginBank} - DestinationBank: {DestinationBank} ";
        }
    }
}
