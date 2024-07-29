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
            try
            {
                var user = await _services.Login(login.UserName, login.PasswordHash);

                if (user == null)
                {
                    TempData["ErrorMessage"] = "Nie poprawny login lub hasło!";
                    return RedirectToAction("Login", "Account");
                }
                TempData["SuccessMessage"] = "Poprawnie się zalogowałeś!";
                return RedirectToAction("Page", "Home");
            }
            catch
            {
                TempData["ErrorMessage"] = "Wystąpił błąd podczas próby zalogowania. Proszę spróbować później.";
                return RedirectToAction("Login", "Account");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register(ApkaAnalizatorDomain.Enties.Account register)
        {
            try
            {
                var registerAccount = await _services.Register(register.UserName, register.PasswordHash);

                if (registerAccount == null)
                {
                    TempData["ErrorMessage"] = "Nie zarejestrowano użytkownika. Proszę spróbować ponownie.";
                    return RedirectToAction("Register", "Account");
                }
                TempData["SuccessMessage"] = "Konto zostało poprawnie utworzone.";
                return RedirectToAction("Register","Account");
            }
            catch 
            {
                TempData["ErrorMessage"] = "Wystąpił błąd podczas próby rejestracji. Proszę spróbować później.";
                return RedirectToAction("Register","Account");
            }
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
