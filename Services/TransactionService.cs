using KRWTransfer.Models;
using KRWTransfer.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace KRWTransfer.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly KRWDbContext _context;
        private readonly UserManager<UserModel> _userManager;
        public TransactionService(KRWDbContext context, UserManager<UserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public int CreateTransfer(Transaction transaction)
        {            
            var fromUserId = GetUserId(transaction.FromUsername);
            var fromAccount = _context.Account.Find(fromUserId);

            var toUserId = GetUserId(transaction.ToUsername);
            var toAccount = _context.Account.Find(toUserId);

            fromAccount.Balance = fromAccount.Balance - transaction.Coins;
            toAccount.Balance = toAccount.Balance + transaction.Coins;

            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            
            return transaction.Id;
        }

        public int GetUserId(string username)
        {
            var userId = _context.Account.FirstOrDefault(x => x.Username == username);
            // var user = _userManager.FindByIdAsync(username);
            if (userId != null)
            {
                return userId.Id;
            } else 
                return 0;
        }
    }
}
