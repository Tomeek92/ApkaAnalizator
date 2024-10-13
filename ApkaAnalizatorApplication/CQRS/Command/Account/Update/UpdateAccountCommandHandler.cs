using ApkaAnalizatorDomain.Enties;
using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Account.Update
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMediator mediator, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<ApkaAnalizatorDomain.Enties.Account>(request);
                await _accountRepository.UpdateAccount(mapp);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania {ex.Message}");
            }
        }
    }
}
