using System;
using BankAccount.Service;

namespace BankAccount
{
    public class Platinum : BankAccount
    {
        IAccountService PlatinumAccountService = new BaseAccountService();

        public override BankAccount CreateAccount(string id, string name, string surname)
        {
            return new Platinum(id, name, surname);
        }

        public override void CloseAccount(ref BankAccount account)
        {
            account = null;
        }

        public override void Deposit(int money)
        {
            Amount += money;
            Bonus += PlatinumAccountService.CalculateBonus(money);
        }

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

        private Platinum(string id, string name, string surname) : base(id, name, surname)
        {
            Bonus = 0;
            Amount = 0;
        }
    }
}
