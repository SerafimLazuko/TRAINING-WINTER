
namespace BankAccount.Service
{
    class BaseAccountService : IAccountService
    {
        int IAccountService.CalculateBonus(int amount)
        {
            return amount / 50;
        }

        bool IAccountService.IsWithdrawAllowed(int debited, long amount)
        {
            return (amount >= debited) ?  true :  false;
        }
    }
}
