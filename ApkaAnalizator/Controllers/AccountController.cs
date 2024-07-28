using ApkaAnalizatorApplication.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizator.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _services;
        public AccountController(IAccountServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task<IActionResult> Login(ApkaAnalizatorDomain.Enties.Account login)
        {
            var user = await _services.Login(login.UserName, login.PasswordHash);

            if (user == null)
            {
                return BadRequest("Nieprawidłowe hasło albo login");
            }

          return  RedirectToAction("Page", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register(ApkaAnalizatorDomain.Enties.Account register)
        {
            var registerAccount = await _services.Register(register.UserName, register.PasswordHash);
            if (registerAccount == null)
            {
                return BadRequest("Nie zarejestrowano użytkownika");
            }

            return View(registerAccount);
        }
        [Authorize]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
           await _services.Logout();
            return RedirectToAction("Login", "Account");
        }
    }
}
