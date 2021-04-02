using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class Account<T> : IEnumerable<T> where T : Movement
    {
        //proprietà 
        public string AccountNumber { get; set; }
        public string BankName { get; set; } = "Banca di Milano";
        public decimal Balance { get; set; }
        public DateTime LastTransactionDate { get => lastDate(transaction); set { } }




        //implemento interfaccia  IEnumerable
        private List<T> transaction = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in transaction)
            {
                yield return item;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        //costruttore
        public Account(string an, decimal b)
        {
            AccountNumber = an;
            Balance = b;
        }

        public static Account<T> operator +(Account<T> a, T m)
        {
            a.Balance += m.MovementAmount;
            m.isIncome = true;
            a.transaction.Add(m);
            a.LastTransactionDate = m.MovementDate;
            Console.WriteLine($"Income movement done:\n{m.ToString()}");
            return a;
        }


        public static Account<T> operator -(Account<T> a, T m)
        {

            a.Balance-= m.MovementAmount;
            m.isIncome = false;
            a.transaction.Add(m);
            a.LastTransactionDate = m.MovementDate;
            Console.WriteLine($"Outlay movemnt done:\n{m.ToString()}");
            return a;
        }

        public static DateTime lastDate(List<T> l)
        {
             DateTime data = l[1].MovementDate;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].MovementDate > data)
                {
                    data = l[i].MovementDate;
                }
            }
            return data;
        }

        public void statement() 
        {
            if (this.transaction == null)
            {
                Console.WriteLine("No transaction in your list!");
            }
            else
            { 
            Console.WriteLine($"\n Account number: {AccountNumber} - {BankName}");
            Console.WriteLine($"Current budjet: {Balance} - Last Movement Date: {LastTransactionDate}");
            foreach (var item in this.transaction)
            {
                Console.WriteLine($"{item.ToString()}");
            }
            }
        }

    }
}