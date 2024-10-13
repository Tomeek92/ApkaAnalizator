using ApkaAnalizatorApplication.DTO;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.Account.Delete
{
    public class DeleteAccountCommand : AccountDTO, IRequest
    {
        public string Id { get; set; }
        public DeleteAccountCommand(string id)
        {
            Id = id;
        }
    }
}
