
namespace Bank
{
   public interface IAccountTransactionService
    {
        public Account Process();
    }

    public interface IAccountService
    {
        public Account GetDetail();
    }
    public interface IAccountSetupService
    {
        public int AddAccount();
    }
    public interface IUserInterface
    {
        public void DisplayAndInvoke();
    }

}