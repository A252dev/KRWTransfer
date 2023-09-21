using KRWTransfer.Models;
using KRWTransfer.Services.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KRWTransfer.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transaction;
        public TransactionController(ITransactionService transaction)
        {
            _transaction = transaction;
        }

        [HttpGet]
        public IActionResult Send(Transaction transaction)
        {
            // FIX
            transaction.FromUsername = User.Identity.Name;
            return View();
        }

        [HttpPost]
        public IActionResult Send(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return View(transaction);
            }

            _transaction.CreateTransfer(transaction);
            return RedirectToAction("Index", "Home");
        }
    }
}
