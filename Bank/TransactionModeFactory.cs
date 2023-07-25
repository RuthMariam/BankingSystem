using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;
using BankProcessingLibrary;
    
namespace Bank
{

    public enum Mode
    {
        credit,
        debit,
        transfer
    }
    public class TransactionModeFactory
    {

        
        public static IBankProcess? CreateTransaction(Mode mode,long accountNumber, double amount)
        {
            if (mode == Mode.credit)
            {
                return new Deposit(accountNumber, amount);
            }
            else if (mode == Mode.debit)
            {
                return new Withdraw(accountNumber, amount);
            }
            else
                return null;
        }

        public static IBankProcess? CreateTranscation(Mode mode,long fromAccountNumber, long toAccountNumber,double amount)
        {
            if(mode== Mode.transfer)
            {
                return new Transfer(fromAccountNumber,toAccountNumber,amount);
            }
            return null;
        }


    }
}
