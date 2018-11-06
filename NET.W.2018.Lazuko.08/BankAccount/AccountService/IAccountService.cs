
namespace BankAccount.Service
{
    interface IAccountService
    {
        int CalculateBonus(int amount);
        bool IsWithdrawAllowed(int debited, long amount);
    }
}
