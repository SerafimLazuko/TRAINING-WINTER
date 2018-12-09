using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace No1.Solution
{
    public class PasswordCheckerService
    {
        public (bool, string) VerifyPassword(string password, IRepository repository, IValidConditions validConditions)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (repository == null)
                throw new ArgumentException($"{repository} is null arg");

            if (validConditions == null)
                throw new ArgumentException($"{validConditions} is null arg");

            if (password == string.Empty)
                return (false, $"{password} is empty ");

            string pattern = validConditions.Conditions;
            
            if(!Regex.IsMatch(password, pattern))
                return (false, $"{password} is not valid!");

            repository.Create(password);

            return (true, "Password is Ok. User was created");
        }
    }
}
