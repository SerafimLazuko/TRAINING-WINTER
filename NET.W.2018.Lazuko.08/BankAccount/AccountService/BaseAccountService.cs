
namespace BankAccount.Service
{
    /// <summary>
    /// Provides functionality for the Base Account Type service
    /// </summary>
    /// <seealso cref="BankAccount.Service.IAccountService" />
    class BaseAccountService : IAccountService
    {
        /// <summary>
        /// Calculates the bonus.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        int IAccountService.CalculateBonus(int amount)
        {
            return amount / 50;
        }

        /// <summary>
        /// Checks is it withdraw allowed.
        /// </summary>
        /// <param name="debited">The debited.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>
        ///   <c>true</c> if [is withdraw allowed] [the specified debited]; otherwise, <c>false</c>.
        /// </returns>
        bool IAccountService.IsWithdrawAllowed(int debited, long amount)
        {
            return (amount >= debited) ?  true :  false;
        }
    }
}
