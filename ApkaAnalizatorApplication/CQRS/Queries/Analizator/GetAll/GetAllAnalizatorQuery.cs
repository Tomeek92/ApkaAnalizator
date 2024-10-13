using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.Analizator.GetAll
{
    public class GetAllAnalizatorQuery : IRequest<List<AnalizatorDTO>>
    {
    }
}
