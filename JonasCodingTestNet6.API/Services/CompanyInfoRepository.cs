using JonasCodingTestNet6.API.DbContexts;
using JonasCodingTestNet6.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace JonasCodingTestNet6.API.Services
{
    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        private readonly CompanyInfoContext _context;

        public CompanyInfoRepository(CompanyInfoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company?> GetCompanyAsync(int companyId)
        {
            return await _context.Companies
                .Where(x => x.Id == companyId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ArSubledger>> GetArSubledgersAsync(int companyId)
        {
            return await _context.ArSubledgers.Where(x => x.CompanyId == companyId).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId)
        {
            return await _context.Employees.Where(x => x.CompanyId == companyId).ToListAsync();
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Boolean> DeleteCompanyAsync(int companyId)
        {
            await _context.Database.BeginTransactionAsync();

            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
            if (company == null)
            {
                return false;
            }

            ArSubledger[] arSubledgers = _context.ArSubledgers.Where(x => x.CompanyId == companyId).ToArray();
            if (arSubledgers.Length > 0)
            {
                _context.ArSubledgers.RemoveRange(arSubledgers);
            }

            Employee[] employees = _context.Employees.Where(x => x.CompanyId == companyId).ToArray();
            if (employees.Length > 0)
            {
                _context.Employees.RemoveRange(employees);
            }


            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();
            return true;
        }

        public async Task<ArSubledger?> GetArSubledgerAsync(int arSubledgerId)
        {
            return await _context.ArSubledgers.FirstOrDefaultAsync(x => x.Id == arSubledgerId);
        }

        public async Task<ArSubledger> CreateArSubledgerAsync(ArSubledger arSubledger)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == arSubledger.CompanyId);
            if (company == null)
            {
                throw new Exception($"Company with Id = {arSubledger.CompanyId} does not exist");
            }
            await _context.ArSubledgers.AddAsync(arSubledger);
            await _context.SaveChangesAsync();
            return arSubledger;
        }

        public async Task<ArSubledger> UpdateArSubledgerAsync(ArSubledger arSubledger)
        {
            _context.ArSubledgers.Update(arSubledger);
            await _context.SaveChangesAsync();
            return arSubledger;
        }

        public async Task<bool> DeleteArSubledgerAsync(int arSubledgerId)
        {
            var arSubledger = await _context.ArSubledgers.FirstOrDefaultAsync(x => x.Equals(arSubledgerId));
            if (arSubledger == null)
            {
                return false;
            }
            _context.ArSubledgers.Remove(arSubledger);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Employee?> GetEmployeeAsync(int employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == employee.CompanyId);
            if (company == null)
            {
                throw new Exception($"Company with Id = {employee.CompanyId} does not exist");
            }
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Equals(employeeId));
            if (employee == null)
            {
                return false;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
