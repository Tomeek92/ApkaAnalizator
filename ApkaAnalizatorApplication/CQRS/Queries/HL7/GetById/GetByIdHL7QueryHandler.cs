using ApkaAnalizatorApplication.DTO;
using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.HL7.GetById
{
    public class GetByIdHL7QueryHandler : IRequestHandler<GetByIdHL7Query, HL7DTO>
    {
        private readonly IMediator _mediator;
        private readonly IHl7Repository _hl7Repository;
        private readonly IMapper _mapper;
        public GetByIdHL7QueryHandler(IMediator mediator, IHl7Repository hl7Repository, IMapper mapper)
        {
            _mediator = mediator;
            _hl7Repository = hl7Repository;
            _mapper = mapper;
        }

        public async Task<HL7DTO> Handle(GetByIdHL7Query request, CancellationToken cancellationToken)
        {
            try
            {
                var getHL7Id = await _hl7Repository.GetHl7ById(request.Id);
                var mapp = _mapper.Map<HL7DTO>(request.Id);
                return mapp;
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania");
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd podczas pobierania Id HL7");
            }
        }
    }
}
