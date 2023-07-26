
namespace Bank
{
   public interface IBankProcess
    {
        public Account Process();
    }

    public interface IGetDetails
    {
        public Account GetDetail();
    }
    public interface IAddAccount
    {
        public int AddAccount();
    }


}