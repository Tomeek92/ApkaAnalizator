using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorApplication.Services.Account
{
    public interface IAccountServices
    {
        Task<ApkaAnalizatorDomain.Enties.Account> Login(string userName, string password);
        Task<ApkaAnalizatorDomain.Enties.Account> Register(string username, string password);
        Task Logout();
    }
}
