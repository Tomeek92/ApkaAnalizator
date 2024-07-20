using ApkaAnalizatorApplication.Services.Analizator;
using ApkaAnalizatorDomain.Enties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizator.Controllers
{
    public class AnalizatorController : Controller
    {
        private readonly IAnalizatorServices _analizatorService;
        public AnalizatorController(IAnalizatorServices analizatorService)
        {
            _analizatorService = analizatorService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ApkaAnalizatorDomain.Enties.Analizator analizator)
        {
            await _analizatorService.Create(analizator);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var analizatorList = await _analizatorService.GetAll();
            return View(analizatorList);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var analizator = await _analizatorService.GetAnalizatorById(id);

            if (analizator == null)
            {
                return NotFound();
            }

            return View(analizator);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Analizator analizator)
        {
            if (id != analizator.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(analizator);
            }

            try
            {
                await _analizatorService.UpdateAnalizator(analizator);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Błąd podczas aktualizacji analizatora: {ex.Message}");
                return View(analizator);
            }
        }
    }
}
