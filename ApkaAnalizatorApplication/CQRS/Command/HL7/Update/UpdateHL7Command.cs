using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.HL7.Update
{
    public class UpdateHL7Command : HL7DTO, IRequest
    {
    }
}
