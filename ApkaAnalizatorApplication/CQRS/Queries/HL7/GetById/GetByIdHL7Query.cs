using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.HL7.GetById
{
    public class GetByIdHL7Query : IRequest<HL7DTO>
    {
        public Guid Id { get; set; }
        public GetByIdHL7Query(Guid id)
        {
            Id = id;
        }
    }
}
