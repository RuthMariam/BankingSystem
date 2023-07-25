using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public enum CreationMode
    {
        Console,
        File
    }
    public class AccountFactory
    {
        public static IAddAccount CreateAccount(CreationMode mode)
        {
            if (mode == CreationMode.Console)
            {
                Console.Write("Enter Account number : ");
                long acc=DataProcessor.ValidateLong(Console.ReadLine());

                Console.Write("Enter Customer name : ");
                string name=Console.ReadLine();

                Console.Write("Enter Balance : ");
                double balance=DataProcessor.ValidateDouble(Console.ReadLine());

                Console.Write("Enter Currency (USD,INR) : ");
                string currency = Console.ReadLine();
                return new ReadfromConsole(acc, name, balance, currency);
            }
            else if (mode == CreationMode.File)
            {
                Console.Write("Enter File name : ");
                string name = Console.ReadLine();
                return new ReadfromFile(name);
            }
            else
                return null;
        }
    }
}
