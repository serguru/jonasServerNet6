using AutoMapper;

namespace JonasCodingTestNet6.API.MapperProfiles
{
    public class CompanyProfile: Profile
    {
        public CompanyProfile()
        {
            CreateMap<Entities.Company, Models.CompanyDto>();
            CreateMap<Models.CompanyDto, Entities.Company>();

            CreateMap<Entities.ArSubledger, Models.ArSubledgerDto>();
            CreateMap<Models.ArSubledgerDto, Entities.ArSubledger>();

            CreateMap<Entities.Employee, Models.EmployeeDto>();
            CreateMap<Models.EmployeeDto, Entities.Employee>();
        }
    }
}
