using System;

namespace BankAccount
{
    /// <summary>
    /// Base type of Bank Account
    /// </summary>
    /// <seealso cref="BankAccount.BankAccount" />
    public class Base : BankAccount
    {
        private const decimal bonusConst = 50;
        private const decimal legalDebt = -1000;

        public Base() : base() { }
        public Base(string id, Person owner) : base(id, owner) { }
        public Base(string id, Person owner, decimal initialСontribution) : base(id, owner, initialСontribution) { }
        
        public override int CalculateBonus(decimal money)
        {
            return (int)(Amount / bonusConst + money / bonusConst);
        }

        public override bool IsWithdrawAllowed(decimal withdrawed)
        {
            return (Math.Abs(legalDebt) + Amount < withdrawed) ? false : true; 
        }
    }
}
