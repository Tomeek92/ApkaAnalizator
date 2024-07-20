using ApkaAnalizatorDomain.Enties;
using ApkaAnalizatorDomain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorInfrastructure.Repository
{
    
    public class AccountRepository : IAccountRepository
    {
        private readonly ApkaAnalizatorDbContext _context;
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;
        public AccountRepository(ApkaAnalizatorDbContext context , SignInManager<Account> signInManager, UserManager<Account> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<Account> Login(string userName , string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _signInManager.UserManager.FindByNameAsync(userName);
                return user;
            }
            return null;
        }
        public async Task<Account> Register(string username, string password)
        {
            var newUser = new Account { UserName = username };
            var result = await _userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
            {
                return newUser;
            }
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Failed to create user: {errors}");
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
