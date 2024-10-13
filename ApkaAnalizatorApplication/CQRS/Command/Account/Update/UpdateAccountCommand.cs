using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Account.Update
{
    public class UpdateAccountCommand : AccountDTO, IRequest
    {
    }
}
