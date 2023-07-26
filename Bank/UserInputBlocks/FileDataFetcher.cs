using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UserInputBlocks
{
    public class FileDataFetcher<T> : UserInputProvider<T>
    {
       
        public T GetUserData() {
            Console.Write("Enter File Name : ");
            string fileName = Console.ReadLine();
            return (T)(Object)fileName;
        }
    }
}
