using ApkaAnalizatorDomain.Enties;


namespace ApkaAnalizatorDomain.Interfaces
{
    public interface IHl7Repository
    {
        Task Create(HL7 hl7);
        Task<List<ApkaAnalizatorDomain.Enties.HL7>> GetAll();
        Task<HL7> GetHl7ById(Guid id);
        Task UpdateHl7(ApkaAnalizatorDomain.Enties.HL7 hl7);
        Task Delete(ApkaAnalizatorDomain.Enties.HL7 hl7);
    }
}
