using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ClassLibrary1;
using BankProcessingLibrary;
namespace Bank
{
    public class Bank
    {

        BankProcessing bp;
        IRead iread;

        public Bank(BankProcessing bp )
        {
            this.bp = bp;
        }


        void Deposit(long accountNumber)
        {
            Console.Write("Enter Amount to be deposited:");
            double amount = getDouble();
             if(amount <= 0)
            {
                Console.WriteLine("Amount should be greater than zero !");
                Deposit(accountNumber);
                return;
            }
            bp.Deposit(accountNumber,amount);
            return;
                
        }
        void WithDraw(long accountNumber)
        {
            Console.Write("Enter Amount to be withdrawn:");
            double amount = getDouble();
            if (amount <= 0)
            {
                Console.WriteLine("Amount should be greater than zero !");
                WithDraw(accountNumber);
                return;
            }
            bp.Withdraw(accountNumber, amount);
            return;

        }
        Account? ValidateAccount(long account_number)
        {
            
            if (account_number == -1)
            {
                Console.WriteLine("The account number of invalid type!\n Press Enter to continue");
               // Console.ReadLine();
                return null;
            }
            Account account = bp.GetDetails(account_number);
            if (account == null)
            {
              //  Console.WriteLine("Invalid Account Number ! \n Press Enter to continue");
               // Console.ReadLine();
                return null;
            }
            return account;
        }
        void Transfer(long fromAccountNumber)
        {
            Console.Write("Enter recepient account number:");
            long toAccountNumber = getInteger();
            Account? toAccount = ValidateAccount(toAccountNumber);
            if (toAccount == null)
            {
                return;
            }
            begin:
            Console.Write("Enter Amount to be transfered:");
            double amount = getDouble();

            if (amount <= 0)
            {
                Console.WriteLine("Amount should be greater than zero !");
                goto begin;
            }
            else
            {
                bp.TransferAmount(fromAccountNumber, toAccountNumber, amount);
            }

        }


        public void ProcessTransaction()
        {
            Console.Clear();

            Console.Write("Enter your Account Number:");
            long account_number = getInteger();
            Account? account = ValidateAccount(account_number);
            if (account == null)
            {
                return;
            }
            Console.WriteLine($"Account Holder: {account.customer.Name} \n" +
                $" Balance: {account.Balance} \n Please Enter to continue");
            Console.ReadLine();
            Menu accountProcessMenu = new Menu() { MenuListItems = {"CREDIT", "WITHDRAWAL", "TRANSFER"},
                menuTitle = "ACCOUNT PROCESS" };
            accountProcessMenu.MenuDisplay();
            long option = getInteger();
            switch(option)
            {
                case 1:
                    Deposit(account.AccountNumber);
                    break;
                case 2: 
                    WithDraw(account.AccountNumber);
                    break;
                case 3:
                    Transfer(account.AccountNumber);
                    break;
                default:
                    Console.WriteLine("Input was not in the option \n Press Enter to Continue");
                    Console.ReadLine();
                    break;
            }
        }

        public void DisplayAccountDetails()

        {

            Console.Write("Enter your Account Number:");
            long account_number = getInteger();
            Account? account = ValidateAccount(account_number);
            if (account == null)
            {
                return;
            }
            Console.WriteLine($"Account Holder: {account.customer.Name} \n" +
                $" Balance: {account.Balance}");
        }

        public void AddAccount()
        {
            Menu userMenu = new Menu()
            {
                MenuListItems = { "READ FROM CONSOLE", "READ FROM FILE" },
                menuTitle = "NEW USER INPUT FORM"
            };
            userMenu.MenuDisplay();

            long option = getInteger();
            switch (option)
            {
                case 1: 
                    this.iread = new ReadFromConsole();
                    iread.Read();
                    break;
                case 2:
                    this.iread = new ReadFromFile();
                    iread.Read();
                    break;
                default:
                    Console.WriteLine("Input was not in the option \n Press Enter to Continue");
                    Console.ReadLine();
                    break;
            }
            return;
        }

        long getInteger()
        {
            long choice;
            try
            {
                choice = Convert.ToInt64(Console.ReadLine());
               
            }
            catch (FormatException e)
            {
                choice = -1;
            }
            return choice;
           
        }


        Double getDouble()
        {
            double choice;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                choice = -1;
            }
            return choice;
        }


        public static void Main(string[] args)
        {
            Menu mainMenu = new Menu() { MenuListItems = { "ADD ACCOUNT", "PERFROM TRANSACTION", 
                    "DISPLAY USER DETAILS","Exit" }, menuTitle = "ADMIN PAGE" };
            
            Bank bank = new Bank(new BankProcessing());
           

            while (true) {
                mainMenu.MenuDisplay();
                long choice = bank.getInteger();

                switch (choice)
                {
                    case 1:  bank.AddAccount();
                            break;
                    case 2: bank.ProcessTransaction();
                            break;
                    case 3: bank.DisplayAccountDetails();
                            break;
                    case 4:
                           Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Input was not in the option \n Press Enter to Continue");
                        break;
                }   



                Console.ReadLine();

                Console.Clear();
            }

        }
    }
}
