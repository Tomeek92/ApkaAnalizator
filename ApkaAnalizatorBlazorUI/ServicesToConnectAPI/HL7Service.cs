namespace ApkaAnalizatorUI.ServicesToConnectAPI
{
    public class HL7Service
    {
        private readonly HttpClient _httpClient;
        public HL7Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7164/api/HL7/");
        }
    }
}
