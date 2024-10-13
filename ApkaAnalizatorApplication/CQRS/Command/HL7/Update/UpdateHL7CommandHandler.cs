using ApkaAnalizatorDomain.Enties;
using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.HL7.Update
{
    public class UpdateHL7CommandHandler : IRequestHandler<UpdateHL7Command>
    {
        private readonly IMapper _mapper;
        private readonly IHl7Repository _hl7Repository;
        public UpdateHL7CommandHandler(IMapper mapper, IHl7Repository hl7Repository)
        {
            _mapper = mapper;
            _hl7Repository = hl7Repository;
        }

        public async Task Handle(UpdateHL7Command request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<ApkaAnalizatorDomain.Enties.HL7>(request);
                await _hl7Repository.UpdateHl7(mapp);
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania");
            }
            catch (Exception ex)
            {
                throw new Exception($"Nieoczekiwany błąd podczas aktualizowania HL7");
            }
        }
    }
}
