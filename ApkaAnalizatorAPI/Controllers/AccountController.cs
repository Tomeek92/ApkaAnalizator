using ApkaAnalizatorApplication.CQRS.Command.Account.Create;
using ApkaAnalizatorApplication.CQRS.Command.Account.Delete;
using ApkaAnalizatorApplication.CQRS.Command.Account.Update;
using ApkaAnalizatorApplication.CQRS.Queries.Account.GetLoggedAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateAccount")]
        public async Task<IActionResult> Create([FromBody] CreateAccountCommand accountCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _mediator.Send(accountCommand);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Nieprawidłowe dane: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message} ");
            }
        }
        [HttpDelete("DeleteAccount/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _mediator.Send(new DeleteAccountCommand(id));
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Nieprawidłowe dane: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono konta: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd serwera {ex.Message}");
            }
        }
        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> Update([FromBody] UpdateAccountCommand accountCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _mediator.Send(accountCommand);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Nieprawidłowe dane: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono konta: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _mediator.Send(new GetLoggedAccountQuery());
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Nieprawidłowe dane: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono konta: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
    }
}
