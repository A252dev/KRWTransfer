using KRWTransfer.Models;
using KRWTransfer.Services;
using KRWTransfer.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KRWTransfer.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<UserModel> _userManager;
		private readonly SignInManager<UserModel> _signInManager;
		private readonly IAccountService _accountService;
        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInMaganer, IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInMaganer;
            _accountService = accountService;
        }

		[HttpGet]
        [Route("/Register")]
        public IActionResult Register()
		{
			return View();
		}
				
		[HttpPost]
        [Route("/Register")]
        public async Task<IActionResult> Register(Register userRegisterData, Account accountinfo)
		{
			if (!ModelState.IsValid)
			{
                return View(userRegisterData);
            }

            var newUser = new UserModel
            {
                Email = userRegisterData.Email,
                UserName = userRegisterData.Username,
            };

			await _userManager.CreateAsync(newUser, userRegisterData.Password);
			_accountService.CreateAccount(accountinfo);

            return RedirectToAction("Index", "Home");
        }
		
		[HttpGet]
        [Route("/Login")]
        public IActionResult Login()
		{
			return View();
		}
		
		[HttpPost]
        [Route("/Login")]
        public async Task <IActionResult> Login(Login userLoginData)
		{
			if (!ModelState.IsValid)
			{
				return View(userLoginData);
			}

			await _signInManager.PasswordSignInAsync(userLoginData.Username, userLoginData.Password, false, false);
			return RedirectToAction("Index", "Home");
		}
		
		public async Task <IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[Route("/Users")]
		public IActionResult UserList()
		{
			var users = _accountService.GetAllAccounts();
			return View(users);
		}

		[HttpPost]
		[Route("/Users")]
        public IActionResult UserList(UserModel account, Account accountInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }			
            _userManager.DeleteAsync(account);
            _accountService.DeleteAccount(accountInfo);
            return RedirectToAction("Index", "Home");
			
        }

		[HttpPost]
		public IActionResult Delete(Account accountInfo)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
            _accountService.DeleteAccount(accountInfo);
            return RedirectToAction("Index", "Home");
		}

	}
}
