using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizator.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
