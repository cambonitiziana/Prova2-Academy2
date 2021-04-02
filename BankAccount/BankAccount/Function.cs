using BankAccount.MovementsEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public  class Function
    {
        public static Account<Movement> NewAccount()
        {
            Console.WriteLine(" Would you like to open a new account?\n");
            AskNewAccount:
            Console.WriteLine(" Yes - press Y   No - press N(quit)");
            string answer1 = Console.ReadLine();
            if (answer1 == "n")
            { return null; }
            else if (answer1 == "y")
            {
                Console.WriteLine("Please, enter account number");
                //dafare eventuale controllo  su tot numero carattei
                string NewAccountNumber = Console.ReadLine();
                Console.WriteLine("Please, enter initial deposit");
                //controllo sul fatto che sia stato inserito un numero
                decimal NewAccountAmount = Convert.ToDecimal(Console.ReadLine());
                Account<Movement> newAccount = new Account<Movement>(NewAccountNumber, NewAccountAmount);
                return newAccount;
            }
            else
            {
                Console.WriteLine("Not valid answer!");
                goto AskNewAccount;
            }
        }

        public static void BankMenù(Account<Movement> account)
        {
            menu:
            Console.WriteLine(  "Choose one option: \n" +
                                "Register a cash transaction - press C\n" +
                                "Register a transfer transaction - press T\n" +
                                "Register a credit card transaction - press R\n" +
                                "Check all transaction - press P\n" +
                                "Quit - press Q");
            string answer = Console.ReadLine();
            switch(answer)
            {
                case "c": //cash
                    Movement m1 = StartingDataMovement();
                    Console.WriteLine("Insert the Esecutor");
                    string Esec= Console.ReadLine();
                    CashMovement cm = new CashMovement(m1.MovementAmount, m1.MovementDate, m1.isIncome,Esec);
                    DoTransaction(cm,account);
                    goto menu;
                    

                 case "t":// transfer
                    Movement m2 = StartingDataMovement();
                    Console.WriteLine("Insert the origin bank:");
                    string ob = Console.ReadLine();
                    Console.WriteLine("Insert the destination bank:");
                    string db = Console.ReadLine();
                    TransfertMovement tm = new TransfertMovement(m2.MovementAmount, m2.MovementDate, m2.isIncome, ob,db);
                    DoTransaction(tm, account);
                    goto menu;
                    

                    case "r": //credit card
                    Movement m3 = StartingDataMovement();
                    insertcard:
                    Console.WriteLine("Insert the cardType\n" +
                        "AMEX - press A\n" +
                        "VISA - press V\n" +
                        "MASTERCARD - press M" +
                        "OTHER -press O");
                    string cardtype = Console.ReadLine();
                    CardType ct;
                    if (cardtype == "a" || cardtype == "v" || cardtype == "m" || cardtype == "o")
                    {
                       ct = type(cardtype);
                    }
                    else 
                    { goto insertcard; }
                    Console.WriteLine("Insert the card number ");
                    string cn= Console.ReadLine();
                    CreditCardMovement ccm = new CreditCardMovement(m3.MovementAmount, m3.MovementDate, m3.isIncome,cn ,ct);
                    DoTransaction(ccm, account);
                    goto menu;
                   

                case "p":
                    account.statement();
                    goto menu;

                case "q":
                    return;
            }
        }

        public static CardType type(string s)
        {
            CardType x = CardType.OTHER ;
            switch (s)
            { case "a":
                   x=CardType.AMEX;
                    break;    
                case "v":
                   x=CardType.VISA;
                    break;
                case "m":
                   x= CardType.MASTERCARD;
                    break;
                  
                case "o":
                    x= CardType.OTHER;
                    break;
            }
            return x;
        }
        public static Movement StartingDataMovement()
        {
            Movement movement = new Movement() { };
            isIncome:
            Console.WriteLine("Press I if you are recording an income transaction;" +
                             "Press O if you are recording an expense ");
            string answer = Console.ReadLine();
            if (answer == "i")
            {
                movement.isIncome = true;
            }
            else if (answer == "o")
            { movement.isIncome = false; }
            else
            {
                Console.WriteLine("Not valid answer");
                goto isIncome;
            }
            Console.WriteLine("Please, insert movement Amount");
            movement.MovementAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please, inset movement Date (yyyy/MM/dd format");
            movement.MovementDate = Convert.ToDateTime(Console.ReadLine());
            return movement;
        }

        public static void DoTransaction(Movement m, Account<Movement> a)
        {
            if (m.isIncome)
            {
                a += m;  
            }
            else 
            { a -= m;   
            }
            
        }

    }
}
