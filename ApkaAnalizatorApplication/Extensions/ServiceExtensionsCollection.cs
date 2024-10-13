using ApkaAnalizatorApplication.CQRS.Command.Account.Create;
using ApkaAnalizatorApplication.CQRS.Command.Account.Delete;
using ApkaAnalizatorApplication.CQRS.Command.Account.Update;
using ApkaAnalizatorApplication.CQRS.Command.Analizator.Create;
using ApkaAnalizatorApplication.CQRS.Command.Analizator.Delete;
using ApkaAnalizatorApplication.CQRS.Command.Analizator.Update;
using ApkaAnalizatorApplication.CQRS.Command.HL7.Create;
using ApkaAnalizatorApplication.CQRS.Command.HL7.Delete;
using ApkaAnalizatorApplication.CQRS.Command.HL7.Update;
using ApkaAnalizatorApplication.CQRS.Queries.Account.GetAll;
using ApkaAnalizatorApplication.CQRS.Queries.Account.GetLoggedAccount;
using ApkaAnalizatorApplication.CQRS.Queries.Analizator.GetAll;
using ApkaAnalizatorApplication.CQRS.Queries.Analizator.GetById;
using ApkaAnalizatorApplication.CQRS.Queries.HL7.GetAll;
using ApkaAnalizatorApplication.CQRS.Queries.HL7.GetById;
using ApkaAnalizatorApplication.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace ApkaAnalizatorApplication.Extensions
{
    public static class ServiceExtensionsCollection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                typeof(CreateAccountCommand).Assembly,
                typeof(UpdateAccountCommand).Assembly,
                typeof(DeleteAccountCommand).Assembly,
                typeof(GetAllAccountQuery).Assembly,
                typeof(GetLoggedAccountQuery).Assembly,

                typeof(CreateAnalizatorCommand).Assembly,
                typeof(UpdateAnalizatorCommand).Assembly,
                typeof(DeleteAnalizatorCommand).Assembly,
                typeof(GetAllAnalizatorQuery).Assembly,
                typeof(GetAnalizatorByIdQuery).Assembly,

                typeof(CreateHL7Command).Assembly,
                typeof(UpdateHL7Command).Assembly,
                typeof(DeleteHL7Command).Assembly,
                typeof(GetAllHL7Query).Assembly,
                typeof(GetByIdHL7Query).Assembly
                ));
            services.AddAutoMapper(typeof(MapperProfile));
        }
    }
}
