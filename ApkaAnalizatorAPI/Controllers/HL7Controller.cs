using ApkaAnalizatorApplication.CQRS.Command.HL7.Create;
using ApkaAnalizatorApplication.CQRS.Command.HL7.Delete;
using ApkaAnalizatorApplication.CQRS.Command.HL7.Update;
using ApkaAnalizatorApplication.CQRS.Queries.HL7.GetAll;
using ApkaAnalizatorApplication.CQRS.Queries.HL7.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HL7Controller : ControllerBase
    {
        private readonly IMediator _mediator;
        public HL7Controller(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateHL7")]
        public async Task<IActionResult> Create(CreateHL7Command createHL7Command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _mediator.Send(createHL7Command);
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
                await _mediator.Send(new DeleteHL7Command(id));
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono HL7: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
        [HttpPut("UpdateHL7")]
        public async Task<IActionResult> Update(UpdateHL7Command updateHL7Command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _mediator.Send(updateHL7Command);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono HL7: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
        [HttpGet("GetByIdHL7")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = _mediator.Send(new GetByIdHL7Query(id));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono HL7: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
        [HttpGet("GetAllHL7")]
        public async Task<IActionResult> GetAllHL7()
        {
            try
            {
                var result = await _mediator.Send(new GetAllHL7Query());
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Nieodnaleziono HL7: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nieoczekiwany błąd: {ex.Message}");
            }
        }
    }
}
