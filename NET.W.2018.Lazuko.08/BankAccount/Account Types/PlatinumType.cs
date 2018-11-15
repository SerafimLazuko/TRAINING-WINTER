using System;

namespace BankAccount
{
    /// <summary>
    /// Platinum account type.
    /// </summary>
    /// <seealso cref="BankAccount.BankAccount" />
    public class Platinum : BankAccount
    {
        private const decimal bonusConst = 10;
        private const decimal legalDebt = -100000;

        public Platinum() : base() { }
        public Platinum(string id, Person owner) : base(id, owner) { }
        public Platinum(string id, Person owner, decimal initialСontribution) : base(id, owner, initialСontribution) { }

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
