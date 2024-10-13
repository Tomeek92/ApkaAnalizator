using ApkaAnalizatorApplication.DTO;
using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.Analizator.GetAll
{
    public class GetAllAnalizatorQueryHandler : IRequestHandler<GetAllAnalizatorQuery, List<AnalizatorDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IAnalizatorRepository _analizatorRepository;
        private readonly IMapper _mapper;
        public GetAllAnalizatorQueryHandler(IMediator mediator, IAnalizatorRepository analizatorRepository, IMapper mapper)
        {
            _mediator = mediator;
            _analizatorRepository = analizatorRepository;
            _mapper = mapper;
        }
        public async Task<List<AnalizatorDTO>> Handle(GetAllAnalizatorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getAllAnalizatorsFromDB = await _analizatorRepository.GetAll();
                var mapp = _mapper.Map<List<AnalizatorDTO>>(request);
                return mapp;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Błąd podczas mapowania");
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas pobierania wszystkich analizatorów");
            }
        }
    }
}
