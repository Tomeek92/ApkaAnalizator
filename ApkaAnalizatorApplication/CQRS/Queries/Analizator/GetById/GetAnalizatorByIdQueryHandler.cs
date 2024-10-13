using ApkaAnalizatorApplication.DTO;
using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.Analizator.GetById
{
    public class GetAnalizatorByIdQueryHandler : IRequestHandler<GetAnalizatorByIdQuery, AnalizatorDTO>
    {
        private readonly IMediator _mediator;
        private readonly IAnalizatorRepository _analizatorRepository;
        private readonly IMapper _mapper;
        public GetAnalizatorByIdQueryHandler(IMediator mediator, IAnalizatorRepository analizatorRepository, IMapper mapper)
        {
            _mediator = mediator;
            _analizatorRepository = analizatorRepository;
            _mapper = mapper;
        }
        public async Task<AnalizatorDTO> Handle(GetAnalizatorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getAnalizatorId = await _analizatorRepository.GetAnalizatorById(request.Id);
                var mapp = _mapper.Map<AnalizatorDTO>(request.Id);
                return mapp;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania");
            }
            catch (Exception e)
            {
                throw new Exception($"Nieoczekiwany błąd podczas pobierania Id analizatora");
            }
        }
    }
}
