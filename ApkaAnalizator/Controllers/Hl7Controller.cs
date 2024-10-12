using ApkaAnalizatorApplication.Services.HL7;
using ApkaAnalizatorDomain.Enties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizator.Controllers
{
    public class Hl7Controller : Controller
    {
        private readonly IHl7Services _hl7Service;
        private readonly ILogger<Hl7Controller> _logger;
        public Hl7Controller(IHl7Services hl7Services, ILogger<Hl7Controller> logger)
        {
            _hl7Service = hl7Services;
            _logger = logger;
        }
        public async Task<IActionResult> Delete(ApkaAnalizatorDomain.Enties.HL7 hl7)
        {
            await _hl7Service.Delete(hl7);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApkaAnalizatorDomain.Enties.HL7 hl7)
        {
            await _hl7Service.Create(hl7);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var analizatorList = await _hl7Service.GetAll();
            return View(analizatorList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var analizator = await _hl7Service.GetHl7ById(id);

            if (analizator == null)
            {
                return NotFound();
            }

            return View(analizator);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Guid id, HL7 hL7)
        {
            if (id != hL7.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(hL7);
            }

            try
            {
                await _hl7Service.UpdateHl7(hL7);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Błąd podczas aktualizacji analizatora: {ex.Message}");
                return View(hL7);
            }
        }
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var hl7 = await _hl7Service.GetHl7ById(id);
                return View(hl7);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Nie znaleziono numer Id dla podłączenia hl7 {id}", id);
                return NotFound();
            }
        }
    }
}
