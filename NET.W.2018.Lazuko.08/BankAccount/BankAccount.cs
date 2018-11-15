using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Abstract class BankAccount
    /// </summary>
    public abstract class BankAccount
    {
        #region Fielsd & Prop

        private Person owner;
        private string id;
        private int bonus;
        private decimal amount;

        public Person Owner
        {
            get => owner;
            private set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                owner.Name = value.Name;
                owner.Surname = value.Surname;
                owner.Email = value.Email;
            }
                
        }
        public string Id
        {
            get => id;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid format of ID");

                id = value;
            }
        }
        public int Bonus
        {
            get => bonus;
            private set
            {
                bonus = value;
            }
        }
        public decimal Amount
        {
            get => amount;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid amount, no change in balance.");

                amount = value;
            }
        }

        #endregion

        #region Ctors

        public BankAccount() { }
        
        public BankAccount(string id, Person owner)
        {
            Id = id;
            Owner = owner;
            Bonus = 0;
            Amount = 0;
        }

        public BankAccount(string id, Person owner, decimal initialСontribution) : this(id, owner)
        {
            Amount = initialСontribution;
            Bonus += CalculateBonus(initialСontribution);
        }

        #endregion
        
        public void Deposit(int money)
        {
            if (money <= 0)
                throw new ArgumentException($"money = {money}, must be positive!");

            Amount += money;
            Bonus += CalculateBonus(money);
        }

        public void Withdraw(decimal money)
        {
            if (!IsWithdrawAllowed(money))
                throw new Exception("Insufficient funds to complete the transaction.");

            Amount -= money;
            Bonus -= CalculateBonus(money);
        }
        
        public abstract int CalculateBonus(decimal money);
        public abstract bool IsWithdrawAllowed(decimal withdrawed);

        #region Overrides

        public override string ToString() => $"Id: {Id}, Owner: {Owner.ToString()}";
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            BankAccount bacc = obj as BankAccount;
            if (Id == bacc.Id && Owner == bacc.Owner)
                return true;

            return false;
        }

        #endregion
    }
}
