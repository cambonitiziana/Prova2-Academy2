using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.MovementsEntities
{
    public class CreditCardMovement:Movement 
    {
        public string CardNumber { get; set; }
        public CardType Type { get; set; }


        public CreditCardMovement(decimal ma, DateTime md,bool b, string cn, CardType ct)
        {
            isIncome = b;
            MovementAmount = ma;
            MovementDate = md;
            CardNumber = cn;
            Type = ct;
        }

        //metodi
        public override string ToString()
        {
            return$"Movement: CREDIT CARD - {IsIncomeString()} - Amount: {MovementAmount} - Date: {MovementDate} -CardNumber: {CardNumber} - Card Type: {Type} ";
        }
    }
    public enum CardType 
    {
        AMEX, VISA, MASTERCARD, OTHER
    }
}
