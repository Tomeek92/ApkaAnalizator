
using ApkaAnalizatorApplication.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApkaAnalizatorUI.ServicesToConnectAPI
{
    public class AccountService
    {
        private readonly HttpClient _httpClient;
        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7164/api/Account/");
        }
        public async Task<AccountDTO> GetCurrentAccount()
        {
            try
            {
                var users = await _httpClient.GetFromJsonAsync<AccountDTO>("GetCurrentUser");
                return users ?? throw new Exception("Nie znaleziono użytkownika");
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"Problem z połączeniem http: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception("Nie udało się pobrać informacji o aktualnym użytkowniku: " + ex.Message);
            }
        }
        public async Task<IActionResult> UpdateAccount(AccountDTO accountDTO)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("UpdateAccount", accountDTO);
                if (response.IsSuccessStatusCode)
                {
                    return new OkResult();
                }
                else
                {
                    throw new Exception("Nieoczekiwany błąd");
                }
            }
            catch (HttpRequestException httpEx)
            {
                return new BadRequestObjectResult($"Problem z połączeniem HTTP: {httpEx.Message}");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
        public async Task<IActionResult> CreateAccount(AccountDTO accountDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("CreateAccount", accountDTO);
                if (response.IsSuccessStatusCode)
                {
                    return new OkResult();
                }
                else
                {
                    throw new Exception("Nieoczekiwany błąd");
                }
            }
            catch (HttpRequestException httpEx)
            {
                return new BadRequestObjectResult($"Problem z połączeniem HTTP: {httpEx.Message}");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
        public async Task<IActionResult> DeleteAccount(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"DeleteAccount/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return new OkResult();
                }
                else
                {
                    throw new Exception("Nieoczekiwany błąd");
                }
            }
            catch (HttpRequestException httpEx)
            {
                return new BadRequestObjectResult($"Problem z połączeniem HTTP: {httpEx.Message}");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
