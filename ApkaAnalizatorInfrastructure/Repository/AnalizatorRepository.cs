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
    public class AnalizatorRepository : IAnalizatorRepository
    {
        private readonly ApkaAnalizatorDbContext _context;
        public AnalizatorRepository(ApkaAnalizatorDbContext context)
        {
            _context = context;
        }
        public async Task Create(Analizator analizator)
        {
            _context.Add(analizator);
           await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Analizator>> GetAll() =>
         await _context.Analizators.ToListAsync();
        public async Task<Analizator> GetAnalizatorById(Guid id)
        {
         return await _context.Analizators.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task UpdateAnalizator(Analizator analizator)
        {
            _context.Entry(analizator).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Analizator analizator)
        {
            _context.Remove(analizator);
            await _context.SaveChangesAsync(); 
        }
       
    }
}
