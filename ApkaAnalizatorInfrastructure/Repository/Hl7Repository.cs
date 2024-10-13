using ApkaAnalizatorDomain.Enties;
using ApkaAnalizatorDomain.Interfaces;
using ApkaAnalizatorInfrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorInfrastructure.Repository
{
    public class HL7Repository : IHl7Repository
    {
        private readonly ApkaAnalizatorDbContext _context;
        public HL7Repository(ApkaAnalizatorDbContext context)
        {
            _context = context;
        }
        public async Task Create(HL7 hl7)
        {
            _context.Add(hl7);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(HL7 hl7)
        {
            _context.Remove(hl7);
            await _context.SaveChangesAsync();
        }
        public async Task<List<HL7>> GetAll() =>
        await _context.HL7s.ToListAsync();
        public async Task<HL7> GetHl7ById(Guid id)
        {
            return await _context.HL7s.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task UpdateHl7(HL7 hl7)
        {
            _context.Entry(hl7).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
