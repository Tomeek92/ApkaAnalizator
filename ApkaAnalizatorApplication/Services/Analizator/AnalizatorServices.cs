using ApkaAnalizatorDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorApplication.Services.Analizator
{
    public class AnalizatorServices : IAnalizatorServices
    {
        private readonly IAnalizatorRepository _analizatorRepository;
        public AnalizatorServices(IAnalizatorRepository analizatorRepository)
        {
            _analizatorRepository = analizatorRepository;
        }
        public async Task Create(ApkaAnalizatorDomain.Enties.Analizator analizator)
        {
            await _analizatorRepository.Create(analizator);
        }

        public async Task Delete(ApkaAnalizatorDomain.Enties.Analizator analizator)
        {
          await  _analizatorRepository.Delete(analizator);
            
        }

        public async Task<IEnumerable<ApkaAnalizatorDomain.Enties.Analizator>> GetAll()
        {
            var analizatorList = await _analizatorRepository.GetAll();
            return analizatorList;
        }
        public async Task<ApkaAnalizatorDomain.Enties.Analizator> GetAnalizatorById(Guid id)
        {
            return await _analizatorRepository.GetAnalizatorById(id);
        }
       public async Task UpdateAnalizator(ApkaAnalizatorDomain.Enties.Analizator analizator)
        {
            await _analizatorRepository.UpdateAnalizator(analizator);  
       
        }
    }
}
