using ApkaAnalizatorDomain.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorDomain.Interfaces
{
    public interface IAnalizatorRepository
    {
        Task Create(ApkaAnalizatorDomain.Enties.Analizator analizator);
        Task<IEnumerable<ApkaAnalizatorDomain.Enties.Analizator>> GetAll();
        Task<Analizator> GetAnalizatorById(Guid id);
        Task UpdateAnalizator(ApkaAnalizatorDomain.Enties.Analizator analizator);
        Task Delete(Analizator analizator);
    }
}
