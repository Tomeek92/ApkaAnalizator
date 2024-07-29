using ApkaAnalizatorApplication.Services.Analizator;
using ApkaAnalizatorDomain.Enties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizator.Controllers
{
    public class AnalizatorController : Controller
    {
        private readonly IAnalizatorServices _analizatorService;
        private readonly ILogger<AnalizatorController> _logger;
        public AnalizatorController(IAnalizatorServices analizatorService, ILogger<AnalizatorController> logger)
        {
            _analizatorService = analizatorService;
            _logger = logger;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ApkaAnalizatorDomain.Enties.Analizator analizator)
        {
            try
            {
                await _analizatorService.Create(analizator);
                TempData["SuccessMessage"] = "Poprawnie utworzyłeś połączenie z analizatorem!";
                return RedirectToAction("Index","Analizator");
            }
            catch
            {
                TempData["ErrorMessage"] = "Nie Poprawnie utworzyłeś połączenie z analizatorem!";
                return RedirectToAction("Analizator", "Home");
            }
        }
        [Authorize]
        public async Task<IActionResult> Delete(ApkaAnalizatorDomain.Enties.Analizator analizator)
        {
            try
            {
                await _analizatorService.Delete(analizator);
                TempData["SuccessMessage"] = "Poprawnie usunąłeś połączenie z analizatorem!";
                return RedirectToAction("Index","Analizator");
            }
            catch
            {
                TempData["ErrorMessage"] = "Nie Poprawnie usunąłeś połączenie z analizatorem!";
                return RedirectToAction("Index", "Analizator");
            }
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var analizatorList = await _analizatorService.GetAll();
                return View(analizatorList);
            }
            catch 
            {
                return BadRequest("Wystąpił problem podczas pobierania listy podłączeń analizatorów z bazą danych spróbuj ponownie później"); 
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var analizator = await _analizatorService.GetAnalizatorById(id);

                if (analizator == null)
                {
                    TempData["ErrorMessage"] = "Nie znaleziono takiego podłączenia w bazie danych! spróbuj ponownie poźniej!";
                    return RedirectToAction("Index", "Analizator");
                }
                return View(analizator);
            }
            catch
            {
                TempData["ErrorMessage"] = "Nieoczekiwany błąd skontaktuj się z administratorem";
                return RedirectToAction("Index", "Analizator");
            }
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Analizator analizator)
        {
            if (id != analizator.Id)
            {
                TempData["ErrorMessage"] = "Złe przypisanie Id do podłączenia!";
                return RedirectToAction("Index", "Analizator");
            }

            if (!ModelState.IsValid)
            {
                return View(analizator);
            }

            try
            {
                await _analizatorService.UpdateAnalizator(analizator);
                TempData["SuccessMessage"] = "Poprawnie zapisałeś zmiany!";
                return RedirectToAction("Index","Analizator");
            }
            catch
            {
                TempData["ErrorMessage"] = "Nieoczekiwany błąd skontaktuj się z administratorem";
                return RedirectToAction("Index", "Analizator");
            }
        }
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var analizator = await _analizatorService.GetAnalizatorById(id);
                return View(analizator);
            }
            catch
            {
                TempData["ErrorMessage"] = "Nieoczekiwany błąd skontaktuj się z administratorem";
                return RedirectToAction("Index", "Analizator");
            }
        }
    }
}
