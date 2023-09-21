using KRWTransfer.Models;
using Microsoft.AspNetCore.Identity;

namespace KRWTransfer.Services.Interfaces
{
    public interface ITransactionService
    {
        int CreateTransfer(Transaction transaction);
        int GetUserId(string username);
    }
}
