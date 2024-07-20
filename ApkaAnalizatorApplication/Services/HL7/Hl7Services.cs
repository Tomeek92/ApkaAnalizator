using ApkaAnalizatorDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorApplication.Services.HL7
{
    public class Hl7Services : IHl7Services
    {
        private readonly IHl7Repository _hl7repository;
        public Hl7Services(IHl7Repository hl7repository)
        {
            _hl7repository = hl7repository;
        }
        public async Task Create(ApkaAnalizatorDomain.Enties.HL7 hl7)
        {
            await _hl7repository.Create(hl7);
        }
        public async Task<IEnumerable<ApkaAnalizatorDomain.Enties.HL7>> GetAll()
        {
            var hl7List = await _hl7repository.GetAll();
            return hl7List;
        }
        public async Task<ApkaAnalizatorDomain.Enties.HL7> GetHl7ById(Guid id)
        {
            return await _hl7repository.GetHl7ById(id);
        }
        public async Task UpdateHl7(ApkaAnalizatorDomain.Enties.HL7 hl7)
        {
            await _hl7repository.UpdateHl7(hl7);

        }
        public async Task Delete(ApkaAnalizatorDomain.Enties.HL7 hl7)
        {
            await _hl7repository.Delete(hl7);
        }
    }
}
