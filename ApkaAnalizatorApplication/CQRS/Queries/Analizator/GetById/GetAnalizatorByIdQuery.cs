using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.Analizator.GetById
{
    public class GetAnalizatorByIdQuery : IRequest<AnalizatorDTO>
    {
        public Guid Id { get; set; }
        public GetAnalizatorByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
