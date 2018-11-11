
namespace BankAccount.Service
{
    /// <summary>
    /// interface that defines methods for working with accounts
    /// </summary>
    interface IAccountService
    {
        int CalculateBonus(int amount);
        bool IsWithdrawAllowed(int debited, long amount);
    }
}
