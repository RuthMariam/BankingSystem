using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.InputBlocks
{
    class WithdrawInput {
        public long accountNumber;
        public double withdrawAmount;
    }
    public class WithdrawInputReader<T> : InputBlockTransferInterface<T>{

        

        public T GetTransactionInputBlock() {

            WithdrawInput withdrawInput = new WithdrawInput();

            Console.Write("Enter Account Number  : ");
            withdrawInput.accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter withdrawal Amount : ");
            withdrawInput.withdrawAmount = Convert.ToDouble(Console.ReadLine());

            return (T)(object) withdrawInput;

        }
    }
}
