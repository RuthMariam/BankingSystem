namespace Bank
{
    public class BankException : Exception
    {
        public BankException(string message)
          : base(message)
        {
        }
    }
    public class InsufficientBalanceException : BankException
    {
        public InsufficientBalanceException(string accountNumber)
          : base($"Insufficient balance in account {accountNumber}.")
        {
        }
    }
    public class InvalidAccountNumberException : BankException
    {
        public InvalidAccountNumberException(string accountNumber)
          : base($"Invalid account number: {accountNumber}.")
        {
        }
    }
    public class AccountAlreadyExistsException : BankException
    {
        public AccountAlreadyExistsException(int createdac)
          : base($"Created {createdac} account(s).")
        {
        }
       
    }

    public class NotIntegerException : BankException
    {
        public NotIntegerException()
          : base("The given input is not an integer.")
        {
        }
    }
}