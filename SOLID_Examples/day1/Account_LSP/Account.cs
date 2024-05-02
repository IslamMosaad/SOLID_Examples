namespace SOLID_Examples.day1.Account_LSP
{
    // Interface for account operations
    public interface IAccount
    {
        decimal Balance { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }

    // Base class for accounts
    public abstract class Account : IAccount
    {
        public decimal Balance { get; protected set; }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public abstract void Withdraw(decimal amount);
    }

    // Savings account with withdrawal fee
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public override void Withdraw(decimal amount)
        {
            // Impose a withdrawal fee
            amount += 5.0m;
            if (Balance >= amount) Balance -= amount;
            else throw new InvalidOperationException("Insufficient balance.");
        }
    }

}
