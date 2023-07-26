using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.InputBlocks
{
    class CreditInput{
        public long accountNumber;
        public double creditAmt;
    }
    public class CreditInputReader<T> : InputBlockTransferInterface<T>
    {
        
        public T GetTransactionInputBlock()
        {
            CreditInput creditInput = new CreditInput();

            Console.WriteLine("Enter the Account Number");
            creditInput.accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the Credit Amount");
            creditInput.creditAmt = Convert.ToDouble(Console.ReadLine());

            return (T)(object)creditInput; 
        }
    }

    
}
