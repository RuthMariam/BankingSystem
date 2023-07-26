using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Bank
{
    public class Bank
    {
        public static void Main(string[] args)
        {
            Menu mainMenu = new Menu() { MenuListItems = { "ADD ACCOUNT", "PERFROM TRANSACTION", 
                    "DISPLAY USER DETAILS","Exit" }, menuTitle = "ADMIN PAGE" };
            
            while (true) 
            {
                mainMenu.MenuDisplay();
                int choice = DataProcessor.ValidateInteger(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddAccountUI.addUser();
                            break;
                    case 2: TransactionUI.ProcessTranscation();
                            break;
                    case 3: AccountDetailsUI.ProcessTransaction();
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

                // this a comment
            }

        }
    }
}
