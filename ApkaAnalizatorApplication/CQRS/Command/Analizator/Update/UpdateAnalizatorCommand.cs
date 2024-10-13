using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Analizator.Update
{
    public class UpdateAnalizatorCommand : AnalizatorDTO, IRequest
    {
    }
}
