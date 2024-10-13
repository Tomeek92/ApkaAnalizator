using ApkaAnalizatorDomain.Enties;

namespace ApkaAnalizatorDomain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> Login(string userName, string password);
        Task Register(Account account, string password);
        Task<Account> FindAccountByEmail(string email);
        Task UpdateAccount(Account account);
        Task Delete(string id);
        Task Logout();
    }
}
