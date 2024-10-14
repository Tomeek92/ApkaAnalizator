using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.HL7.Delete
{
    public class DeleteHL7Command : HL7DTO, IRequest
    {
        public Guid Id { get; set; }
        public DeleteHL7Command(Guid id)
        {
            Id = id;
        }
    }
}
