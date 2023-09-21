using KRWTransfer.Models;
using KRWTransfer.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KRWTransfer.Services
{
    public class AccountService : IAccountService
    {
        private readonly KRWDbContext _context;
        private readonly UserManager<UserModel> _userManager;
        public AccountService(KRWDbContext context, UserManager<UserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public int CreateAccount(Account accountinfo)
        {
            _context.Add(accountinfo);
            _context.SaveChanges();
            return accountinfo.Id;
        }

        public int DeleteAccount(Account accountinfo)
        {
            _context.Remove(accountinfo);
            _context.SaveChanges();
            return accountinfo.Id;
        }

        public List<UserModel> GetAllAccounts()
        {
            var users = _userManager.Users.ToList();
            return users;
        }
    }
}
