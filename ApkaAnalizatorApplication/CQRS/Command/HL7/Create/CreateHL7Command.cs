using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.HL7.Create
{
    public class CreateHL7Command : HL7DTO, IRequest
    {
    }
}
