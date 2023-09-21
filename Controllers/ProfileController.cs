using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KRWTransfer.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Main(string username, int balance)
        {
            return View();
        }
    }
}
