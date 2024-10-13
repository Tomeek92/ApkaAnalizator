using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Queries.Account.GetLoggedAccount
{
    public class GetLoggedAccountQuery : IRequest<AccountDTO>
    {
    }
}
