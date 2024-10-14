using ApkaAnalizatorApplication.CQRS.Command.Account.Update;
using ApkaAnalizatorApplication.CQRS.Command.Analizator.Create;
using ApkaAnalizatorApplication.CQRS.Command.Analizator.Delete;
using ApkaAnalizatorApplication.CQRS.Queries.Analizator.GetAll;
using ApkaAnalizatorApplication.CQRS.Queries.Analizator.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalizatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnalizatorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateAnalizator")]
        public async Task<IActionResult> Create([FromBody] CreateAnalizatorCommand createAnalizator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _mediator.Send(createAnalizator);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Nieprawidłowe dane: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var command = new DeleteAnalizatorCommand();
                await _mediator.Send(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Nieprawidłowe dane: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono analizatora: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
        [HttpPut("UpdateAnalizator")]
        public async Task<IActionResult> Update([FromBody] UpdateAccountCommand updateAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _mediator.Send(updateAccount);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Nieprawidłowe dane: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono analizator: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
        [HttpGet("GetAllAnalizators")]
        public async Task<IActionResult> GetAllAnalizators()
        {
            try
            {
                var result = await _mediator.Send(new GetAllAnalizatorQuery());
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono analizator: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
        [HttpGet("GetAnalizatorById")]
        public async Task<IActionResult> GetAnalizatorById(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetAnalizatorByIdQuery(id));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono analizator: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
    }
}
