using System;
using BankAccount.Service;

namespace BankAccount
{
    public class Gold : BankAccount
    {
        IAccountService GoldAccountService = new BaseAccountService();
        
        public override BankAccount CreateAccount(string id, string name, string surname)
        {
            return new Gold(id, name, surname);
        }

        public override void CloseAccount(ref BankAccount account)
        {
            account = null;
        }

        public override void Deposit(int money)
        {
            Amount += money;
            Bonus += GoldAccountService.CalculateBonus(money);
        }

        public override void Withdraw(int money)
        {
            if (GoldAccountService.IsWithdrawAllowed(money, Amount))
            {
                Amount -= money;
                Bonus -= GoldAccountService.CalculateBonus(money);
            }
            else
                throw new Exception("Insufficient funds to complete the transaction.");
        }

        private Gold(string id, string name, string surname) : base(id, name, surname)
        {
            Bonus = 0;
            Amount = 0;
        }
    }
}
