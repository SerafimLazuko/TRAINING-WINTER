
namespace BankAccount
{
    public abstract class BankAccount
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Bonus { get;  set; }
        public long Amount { get;  set; }

        public abstract BankAccount CreateAccount(string id, string name, string surname);
        public abstract void CloseAccount(ref BankAccount account);
        public abstract void Deposit(int money);
        public abstract void Withdraw(int money);

        public BankAccount(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
