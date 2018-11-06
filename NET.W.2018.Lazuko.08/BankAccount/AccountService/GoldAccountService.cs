
namespace BankAccount.Service
{
    class GoldAccountService : IAccountService
    {
        int IAccountService.CalculateBonus(int amount)
        {
            return amount / 20;
        }

        bool IAccountService.IsWithdrawAllowed(int debited, long amount)
        {
            return (amount >= debited) ? true : false;
        }
    }
}
