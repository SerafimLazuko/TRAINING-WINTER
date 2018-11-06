using System;
using BankAccount.Service;

namespace BankAccount
{
    public class Base : BankAccount
    {
        IAccountService BaseAccountService = new BaseAccountService();
        
        public override BankAccount CreateAccount(string id, string name, string surname)
        {
            return new Base(id, name, surname);
        }

        public override void CloseAccount(ref BankAccount account)
        {
            account = null;
        }

        public override void Deposit(int money)
        {
            Amount += money;
            Bonus += BaseAccountService.CalculateBonus(money);
        }
        
        public override void Withdraw(int money)
        {
            if (BaseAccountService.IsWithdrawAllowed(money, Amount))
            {
                Amount -= money;
                Bonus -= BaseAccountService.CalculateBonus(money);
            }
            else
                throw new Exception("Insufficient funds to complete the transaction.");
        }

        private Base(string id, string name, string surname) : base(id, name, surname)
        {
            Bonus = 0;
            Amount = 0;
        }
    }
}
