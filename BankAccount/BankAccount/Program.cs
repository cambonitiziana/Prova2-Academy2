using BankAccount.MovementsEntities;
using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to you bank");

            Account<Movement> newAccount= Function.NewAccount();
            Function.BankMenù(newAccount);
            
        
        }
    }
}
