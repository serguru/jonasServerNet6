using JonasCodingTestNet6.API.Entities;
using JonasCodingTestNet6.API.Models;

namespace JonasCodingTestNet6.API.Services
{
    public interface ICompanyInfoRepository
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company?> GetCompanyAsync(int companyId);
        Task<IEnumerable<ArSubledger>> GetArSubledgersAsync(int companyId);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId);

        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task<Boolean> DeleteCompanyAsync(int companyId);

        Task<ArSubledger?> GetArSubledgerAsync(int arSubledgerId);
        Task<ArSubledger> CreateArSubledgerAsync(ArSubledger arSubledger);
        Task<ArSubledger> UpdateArSubledgerAsync(ArSubledger arSubledger);
        Task<Boolean> DeleteArSubledgerAsync(int arSubledgerId);

        Task<Employee?> GetEmployeeAsync(int employeeId);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<Boolean> DeleteEmployeeAsync(int employeeId);

    }
}
