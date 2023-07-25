using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public enum detailMode
    {
        console
    }
    public class GetDetailsFactory
    {
        public static IGetDetails? CreateTransaction(detailMode mode, long accountNumber)
        {
            if (mode == detailMode.console)
            {
                return new GetDetailsConsole(accountNumber);
            }
            else
                return null;
        }
    }
}
