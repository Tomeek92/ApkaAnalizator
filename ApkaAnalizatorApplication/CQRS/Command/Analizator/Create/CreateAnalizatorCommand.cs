using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Analizator.Create
{
    public class CreateAnalizatorCommand : AnalizatorDTO, IRequest
    {
    }
}
