using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.HL7.GetAll
{
    public class GetAllHL7Query : IRequest<List<HL7DTO>>
    {

    }
}
