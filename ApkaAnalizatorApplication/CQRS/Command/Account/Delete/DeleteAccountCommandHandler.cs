using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Account.Delete
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public DeleteAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _accountRepository.Delete(request.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
