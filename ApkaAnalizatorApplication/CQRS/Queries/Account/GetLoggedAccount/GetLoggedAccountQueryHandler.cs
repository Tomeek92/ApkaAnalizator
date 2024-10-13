using ApkaAnalizatorApplication.DTO;
using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApkaAnalizatorApplication.CQRS.Queries.Account.GetLoggedAccount
{
    public class GetLoggedAccountQueryHandler : IRequestHandler<GetLoggedAccountQuery, AccountDTO>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetLoggedAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<AccountDTO> Handle(GetLoggedAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
                var surName = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Surname);

                if (string.IsNullOrEmpty(userId))
                {
                    throw new UnauthorizedAccessException("Nie znaleziono zalogowanego użytkownika.");
                }
                var accountDTO = new AccountDTO()
                {
                    FirstName = userName,
                    LastName = surName,
                    Id = userId
                };

                return accountDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd podczas przetwarzania zapytania");
            }
        }
    }
}
