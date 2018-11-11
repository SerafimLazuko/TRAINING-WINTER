using System;
using BankAccount.Service;

namespace BankAccount
{
    /// <summary>
    /// Platinum account type.
    /// </summary>
    /// <seealso cref="BankAccount.BankAccount" />
    public class Platinum : BankAccount
    {
        IAccountService PlatinumAccountService = new BaseAccountService();

        /// <summary>
        /// Allows create new account of this user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override BankAccount CreateAccount(string id)
        {
            return new Platinum(id, this.Name, this.Surname);
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="account">The account.</param>
        public override void CloseAccount(ref BankAccount account)
        {
            account = null;
        }

        /// <summary>
        /// Makes deposit and replenishes bonus points.
        /// </summary>
        /// <param name="money">The money.</param>
        public override void Deposit(int money)
        {
            Amount += money;
            Bonus += PlatinumAccountService.CalculateBonus(money);
        }

        /// <summary>
        /// Withdraws the money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <exception cref="System.Exception">Insufficient funds to complete the transaction.</exception>
        public override void Withdraw(int money)
        {
            if (PlatinumAccountService.IsWithdrawAllowed(money, Amount))
            {
                Amount -= money;
                Bonus -= PlatinumAccountService.CalculateBonus(money);
            }
            else
                throw new Exception("Insufficient funds to complete the transaction.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Platinum"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        private Platinum(string id, string name, string surname) : base(id, name, surname)
        {
            Bonus = 0;
            Amount = 0;
        }
    }
}
