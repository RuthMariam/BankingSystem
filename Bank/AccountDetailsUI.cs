using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class AccountDetailsUI : IUserInterface
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
