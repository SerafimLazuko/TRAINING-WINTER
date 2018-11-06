
namespace BankAccount.Service
{
    class PlatinumAccountService : IAccountService
    {
        int IAccountService.CalculateBonus(int amount)
        {
            return amount / 10;
        }

        bool IAccountService.IsWithdrawAllowed(int debited, long amount)
        {
            return (amount >= debited) ? true : false;
        }
    }
}
