
using Microsoft.AspNetCore.Identity;
namespace ApkaAnalizatorDomain.Enties
{
    public class Account : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
