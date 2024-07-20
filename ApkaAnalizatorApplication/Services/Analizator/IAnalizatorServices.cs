using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorApplication.Services.Analizator
{
    public interface IAnalizatorServices
    {
        Task Create(ApkaAnalizatorDomain.Enties.Analizator analizator);
        Task<IEnumerable<ApkaAnalizatorDomain.Enties.Analizator>> GetAll();
        Task<ApkaAnalizatorDomain.Enties.Analizator> GetAnalizatorById(Guid id);
        Task UpdateAnalizator(ApkaAnalizatorDomain.Enties.Analizator analizator);
        Task Delete(ApkaAnalizatorDomain.Enties.Analizator analizator);
    }
}
