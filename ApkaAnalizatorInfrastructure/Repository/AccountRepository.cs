using ApkaAnalizatorDomain.Enties;
using ApkaAnalizatorDomain.Interfaces;
using ApkaAnalizatorInfrastructure.DbContext;
using Microsoft.AspNetCore.Identity;

namespace ApkaAnalizatorInfrastructure.Repository
{

    public class AccountRepository : IAccountRepository
    {
        private readonly ApkaAnalizatorDbContext _context;
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;
        public AccountRepository(ApkaAnalizatorDbContext context, SignInManager<Account> signInManager, UserManager<Account> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<Account> FindAccountByEmail(string email)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    return existingUser;
                }
                else
                {
                    throw new KeyNotFoundException($"Nie odnaleziono użytkownika w bazie danych");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas znajdywania użytkownika w bazie danych");
            }
        }
        public async Task<Account> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _signInManager.UserManager.FindByNameAsync(userName);
                return user;
            }
            return null;
        }
        public async Task Register(Account account, string password)
        {
            try
            {
                await _userManager.CreateAsync(account, password);
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany bląd podczas tworzenia użytkownika {ex}");
            }
        }
        public async Task UpdateAccount(Account account)
        {
            try
            {
                await FindAccountByEmail(account.Email);
                await _userManager.UpdateAsync(account);
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas aktualizowaniu danych użytkownika");
            }
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task Delete(string id)
        {
            try
            {
                var findIdUser = await _userManager.FindByIdAsync(id);
                if (findIdUser == null)
                {
                    throw new KeyNotFoundException($"Nie odnaleziono Id użytkownika");
                }
                await _userManager.DeleteAsync(findIdUser);
            }
            catch (Exception)
            {
                throw new Exception($"Błąd podczas usuwania użytkownika");
            }
        }
    }
}
