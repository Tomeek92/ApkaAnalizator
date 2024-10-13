using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Account.Create
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly IMediator _mediator;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public CreateAccountCommandHandler(IMediator mediator, IAccountRepository accountRepository, IMapper mapper)
        {
            _mediator = mediator;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _accountRepository.FindAccountByEmail(request.Email);
                if (existingUser == null)
                {
                    throw new Exception($"Użytkownik już istnieje w bazie danych!");
                }
                var mapp = _mapper.Map<ApkaAnalizatorDomain.Enties.Account>(request);

                await _accountRepository.Register(mapp, request.Password);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania");
            }
        }
    }
}
