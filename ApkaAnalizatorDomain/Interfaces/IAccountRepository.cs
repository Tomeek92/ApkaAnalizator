using ApkaAnalizatorDomain.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorDomain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> Login(string userName, string password);
        Task<Account> Register(string username, string password);
        Task Logout();
    }
}
