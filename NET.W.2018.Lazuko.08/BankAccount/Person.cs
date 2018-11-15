using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Class Person, provides info about owner of Bank Accounts
    /// </summary>
    public class Person
    {
        #region Fields & Prop

        private string name;
        private string surname;
        private string email;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        #endregion

        #region Ctor

        public Person() { }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(Person person)
        {
            if (person != null)
                throw new ArgumentNullException(nameof(person));

            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;            
        }

        #endregion

        #region Overrides

        public override string ToString() => $"Person =  Name: {Name}, Surname: {Surname}, Email: {Email};";
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            
            Person p = obj as Person;
            if(Name == p.Name && Surname == p.Surname && Email == p.Email)
                return true;

            return false;
        }

        #endregion
    }
}
