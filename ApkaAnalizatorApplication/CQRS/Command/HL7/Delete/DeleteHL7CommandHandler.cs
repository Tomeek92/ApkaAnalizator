using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.HL7.Delete
{
    public class DeleteHL7CommandHandler : IRequestHandler<DeleteHL7Command>
    {
        private readonly IMapper _mapper;
        private readonly IHl7Repository _hl7Repository;
        public DeleteHL7CommandHandler(IMapper mapper, IHl7Repository hl7Repository)
        {
            _mapper = mapper;
            _hl7Repository = hl7Repository;
        }

        public async Task Handle(DeleteHL7Command request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<ApkaAnalizatorDomain.Enties.HL7>(request);
                await _hl7Repository.Delete(mapp);
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania");
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd podczas usuwania HL7");
            }
        }
    }
}
