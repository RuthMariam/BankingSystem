using BankProcessingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//using BankProcessingLibrary;
namespace Bank
{
    public class ReadfromConsole : IAddAccount
    {
        //private readonly BankProcessing bp;
        //public ReadfromConsole()
        //{ }

        //public bool AddAccount()
        //{
        //    //read input here
        //    return true;
        //}
        Account account;
        public ReadfromConsole(long acc, string customerName, double bal, string curr)
        {
            account = new Account(customerName);
            account.AccountNumber = acc;
            account.Balance = bal;
            account.Currency = curr;
        }
        public int AddAccount()
        {
            IRead Input = new ReadFromConsole(account);
            int count = Input.AddAccount();
            if ( count == 0)
            {
                throw new AccountAlreadyExistsException(0);
                
            }
            return count;
        }


    }
}
