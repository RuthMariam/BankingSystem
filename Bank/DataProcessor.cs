using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class DataProcessor
    {

        public static Double ValidateDouble(String number)
        {
            if (Double.TryParse(number, out var result)){
                return result;
            }
            throw new FormatException("Invalid Input Type");
        }

        public static long ValidateLong(String number)
        {
            if (Int64.TryParse(number, out var result))
            {
                return result;
            }
            throw new FormatException("Invalid Input Type");
        }

        public static int ValidateInteger(String number)
        {
            if (Int32.TryParse(number, out var result))
            {
                return result;
            }
            throw new FormatException("Invalid Input Type");
        }



    }
}
