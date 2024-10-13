using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Analizator.Update
{
    public class UpdateAnalizatorCommandHandler : IRequestHandler<UpdateAnalizatorCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAnalizatorRepository _analizatorRepository;
        public UpdateAnalizatorCommandHandler(IMapper mapper, IAnalizatorRepository analizatorRepository)
        {
            _mapper = mapper;
            _analizatorRepository = analizatorRepository;
        }
        public async Task Handle(UpdateAnalizatorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<ApkaAnalizatorDomain.Enties.Analizator>(request);
                await _analizatorRepository.UpdateAnalizator(mapp);
            }
            catch (AutoMapperConfigurationException ex)
            {
                throw new AutoMapperConfigurationException($"Błąd podczas mapowania");
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd aktualizowania analizatora ");
            }
        }
    }
}
