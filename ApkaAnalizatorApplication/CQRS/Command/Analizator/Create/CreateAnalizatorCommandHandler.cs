using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Analizator.Create
{
    public class CreateAnalizatorCommandHandler : IRequestHandler<CreateAnalizatorCommand>
    {
        private readonly IMediator _mediator;
        private readonly IAnalizatorRepository _analizatorRepository;
        private readonly IMapper _mapper;
        public CreateAnalizatorCommandHandler(IMediator mediator, IAnalizatorRepository analizatorRepository, IMapper mapper)
        {
            _mediator = mediator;
            _analizatorRepository = analizatorRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreateAnalizatorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<ApkaAnalizatorDomain.Enties.Analizator>(request);
                await _analizatorRepository.Create(mapp);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas tworzenie nowego analizatora");
            }
        }
    }
}
