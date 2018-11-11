
namespace BankAccount
{
    /// <summary>
    /// describes the entity and defines functions for working with objects of the BankAccount class
    /// </summary>
    public abstract class BankAccount
    {
        #region Properties

        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Bonus { get;  set; }
        public long Amount { get;  set; }

        #endregion

        #region Abstract methods

        public abstract BankAccount CreateAccount(string id);
        public abstract void CloseAccount(ref BankAccount account);
        public abstract void Deposit(int money);
        public abstract void Withdraw(int money);

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        public BankAccount(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
