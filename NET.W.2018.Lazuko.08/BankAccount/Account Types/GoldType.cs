using System;

namespace BankAccount
{
    /// <summary>
    /// Gold type of Bank Account
    /// </summary>
    /// <seealso cref="BankAccount.BankAccount" />
    public class Gold : BankAccount
    {
        private const decimal bonusConst = 30;
        private const decimal legalDebt = -10000;

        public Gold() : base() { }
        public Gold(string id, Person owner) : base(id, owner) { }
        public Gold(string id, Person owner, decimal initialСontribution) : base(id, owner, initialСontribution) { }

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
