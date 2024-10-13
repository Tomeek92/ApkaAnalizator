﻿using ApkaAnalizatorDomain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApkaAnalizatorApplication.CQRS.Command.HL7.Create
{
    public class CreateHL7CommandHandler : IRequestHandler<CreateHL7Command>
    {
        private readonly IMapper _mapper;
        private readonly IHl7Repository _hl7Repository;
        public CreateHL7CommandHandler(IMapper mapper, IHl7Repository hl7Repository)
        {
            _mapper = mapper;
            _hl7Repository = hl7Repository;
        }

        public async Task Handle(CreateHL7Command request, CancellationToken cancellationToken)
        {
            try
            {
                var mapp = _mapper.Map<ApkaAnalizatorDomain.Enties.HL7>(request);
                await _hl7Repository.Create(mapp);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMapperMappingException($"Błąd podczas mapowania");
            }
            catch (Exception ex)
            {
                throw new Exception($"Bład podczas tworzenia HL7 {ex.Message}");
            }
        }
    }
}
