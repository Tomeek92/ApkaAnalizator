using ApkaAnalizatorApplication.DTO;
using ApkaAnalizatorDomain.Enties;
using AutoMapper;

namespace ApkaAnalizatorApplication.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, AccountDTO>();

            CreateMap<AccountDTO, AccountDTO>();

            CreateMap<HL7, HL7DTO>();

            CreateMap<HL7DTO, HL7>();

            CreateMap<Analizator, AnalizatorDTO>();

            CreateMap<AnalizatorDTO, Analizator>();

        }
    }
}
