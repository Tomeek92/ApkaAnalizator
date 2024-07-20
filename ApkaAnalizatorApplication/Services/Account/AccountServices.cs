using ApkaAnalizatorDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorApplication.Services.Account
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _accountRepository;
        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ApkaAnalizatorDomain.Enties.Account> Login(string userName, string password)
        {
            return await _accountRepository.Login(userName, password);
        }

        public async Task Logout()
        {
           await _accountRepository.Logout();
        }

       public async Task<ApkaAnalizatorDomain.Enties.Account> Register(string username, string password)
        {
            return await _accountRepository.Register(username, password);   
        }
    }
}
