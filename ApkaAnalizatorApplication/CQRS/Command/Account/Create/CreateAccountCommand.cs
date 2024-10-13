using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Account.Create
{
    public class CreateAccountCommand : AccountDTO, IRequest
    {


    }
}
