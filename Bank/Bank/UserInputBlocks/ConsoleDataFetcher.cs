using BankProcessingLibrary;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UserInputBlocks
{
    
    public class ConsoleDataFetcher<T> : UserInputProvider<T>
    {

        public T GetUserData() {

            Console.Write("Enter User Name : ");
            string name = Console.ReadLine();
            Account account = new Account(name);
            Console.Write("Enter Account Number : ");
            account.AccountNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter Balance : ");
            account.Balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Currency(USD,INR)");
            account.Currency = Console.ReadLine();

            return (T)(object) account;


        }
    }
}
