namespace ApkaAnalizatorUI.ServicesToConnectAPI
{
    public class AnalizatorService
    {
        private readonly HttpClient _httpClient;
        public AnalizatorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7164/api/Analizator/");
        }
    }
}
