namespace TheBank_NetCore
{
    public interface IBank
    {
        bool AccountExists(string accountHolder);
        void CreateAccount(string accountHolder);
        void Deposit(string accountHolder, decimal amount);
        decimal GetBalance(string accountHolder);
        bool Transfer(string fromAccount, string toAccount, decimal amount);
        bool Withdraw(string accountHolder, decimal amount);
    }
}
