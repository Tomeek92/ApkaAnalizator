using ApkaAnalizatorApplication.DTO;
using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.HL7.GetAll
{
    public class GetAllHL7QueryHandler : IRequestHandler<GetAllHL7Query, List<HL7DTO>>
    {
        private readonly IMediator _mediator;
        private readonly IHl7Repository _hl7Repository;
        private readonly IMapper _mapper;
        public GetAllHL7QueryHandler(IMediator mediator, IHl7Repository hl7Repository, IMapper mapper)
        {
            _mediator = mediator;
            _hl7Repository = hl7Repository;
            _mapper = mapper;
        }
        public async Task<List<HL7DTO>> Handle(GetAllHL7Query request, CancellationToken cancellationToken)
        {
            try
            {
                var allHL7FromDb = _hl7Repository.GetAll();
                var mapp = _mapper.Map<List<HL7DTO>>(request);
                return mapp;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Błąd podczas mapowania");
            }
            catch (Exception ex)
            {
                throw new Exception("Nieoczekiwany błąd podczas pobierania wszystkich HL7");
            }
        }
    }
}
