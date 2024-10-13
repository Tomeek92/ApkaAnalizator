using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Analizator.Delete
{
    public class DeleteAnalizatorCommand : AnalizatorDTO, IRequest
    {
    }
}
