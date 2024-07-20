using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorApplication.Services.HL7
{
    public interface IHl7Services
    {
        Task Create(ApkaAnalizatorDomain.Enties.HL7 hl7);
        Task<IEnumerable<ApkaAnalizatorDomain.Enties.HL7>> GetAll();
        Task<ApkaAnalizatorDomain.Enties.HL7> GetHl7ById(Guid id);
        Task UpdateHl7(ApkaAnalizatorDomain.Enties.HL7 hL7);
        Task Delete(ApkaAnalizatorDomain.Enties.HL7 hL7);
    }
}
