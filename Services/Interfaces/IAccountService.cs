using KRWTransfer.Models;

namespace KRWTransfer.Services.Interfaces
{
    public interface IAccountService
    {
        int CreateAccount(Account accountinfo);
        int DeleteAccount(Account accountinfo);
        List<UserModel> GetAllAccounts();
    }
}
