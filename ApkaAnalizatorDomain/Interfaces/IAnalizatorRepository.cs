using ApkaAnalizatorDomain.Enties;

namespace ApkaAnalizatorDomain.Interfaces
{
    public interface IAnalizatorRepository
    {
        Task Create(ApkaAnalizatorDomain.Enties.Analizator analizator);
        Task<List<ApkaAnalizatorDomain.Enties.Analizator>> GetAll();
        Task<Analizator> GetAnalizatorById(Guid id);
        Task UpdateAnalizator(ApkaAnalizatorDomain.Enties.Analizator analizator);
        Task Delete(ApkaAnalizatorDomain.Enties.Analizator analizator);
    }
}
