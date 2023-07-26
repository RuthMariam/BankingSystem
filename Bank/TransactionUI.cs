using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank
{
    public class TransactionUI : IUserInterface
    {

        public void Function()
        {
            
            Console.Clear();
            Console.Write("Enter your Account Number:");
            try
            {
                long accountNumber = DataProcessor.ValidateLong(Console.ReadLine());
                var IDetails = GetDetailsFactory.CreateTransaction(detailMode.console, accountNumber);
                DetailManager dm = new DetailManager(IDetails);
                Account account = dm.MakeTransaction();
                if (account == null)
                {
                    return;
                }
                Console.WriteLine($"Account Holder: {account.customer.Name} \n" +
                $" Balance: {account.Balance} \n Please Enter to continue");
                Console.ReadLine();

                Menu mainMenu = new Menu()
                {
                    MenuListItems = { "WITHDRAW", "DEPOSIT",
                    "TRANSFER" },
                    menuTitle = "TRANSACTION PAGE"
                };
                mainMenu.MenuDisplay();
                

                int choice = DataProcessor.ValidateInteger(Console.ReadLine());
                IBankProcess? service = null;

                Console.Write("Enter the amount : ");
                double amount = DataProcessor.ValidateDouble(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                         service = TransactionModeFactory.CreateTransaction(Mode.debit, accountNumber, amount); 
                        
                        break;
                    case 2: service = TransactionModeFactory.CreateTransaction(Mode.credit,accountNumber,amount);
                        break;
                    case 3:

                        Console.Write("Enter Recipient account number : ");
                        long toAccount = DataProcessor.ValidateLong(Console.ReadLine());
                        IDetails = GetDetailsFactory.CreateTransaction(detailMode.console, accountNumber);
                        dm = new DetailManager(IDetails);
                        account = dm.MakeTransaction();

                        service = TransactionModeFactory.CreateTranscation(Mode.transfer,accountNumber,toAccount,amount);
                        break;
                }

                TransactionManager tm = new TransactionManager(service);
                Account UpdatedAccount=tm.MakeTransaction();
                //Account UpdatedAccount = service.Process();
                Console.WriteLine($"New Balance : {UpdatedAccount.Balance}  \n Please Enter to continue");
                Console.ReadLine();




            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }


    }
}
