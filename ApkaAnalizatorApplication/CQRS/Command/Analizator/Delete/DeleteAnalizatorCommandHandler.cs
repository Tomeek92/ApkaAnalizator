using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Analizator.Delete
{
    public class DeleteAnalizatorCommandHandler : IRequestHandler<DeleteAnalizatorCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAnalizatorRepository _analizatorRepository;
        public DeleteAnalizatorCommandHandler(IMapper mapper, IAnalizatorRepository analizatorRepository)
        {
            _mapper = mapper;
            _analizatorRepository = analizatorRepository;
        }
        public async Task Handle(DeleteAnalizatorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<ApkaAnalizatorDomain.Enties.Analizator>(request);
                await _analizatorRepository.Delete(mapp);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas usuwania");
            }
        }
    }
}
