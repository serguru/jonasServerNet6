using JonasCodingTestNet6.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace JonasCodingTestNet6.API.DbContexts
{
    public class CompanyInfoContext: DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<ArSubledger> ArSubledgers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public CompanyInfoContext(DbContextOptions<CompanyInfoContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company()
                {
                    Id = 1,
                    CompanyCode = "CompanyCode1",
                    CompanyName = "CompanyName1",
                },
                new Company()
                {
                    Id = 2,
                    CompanyCode = "CompanyCode2",
                    CompanyName = "CompanyName2",
                },
                new Company()
                {
                    Id = 3,
                    CompanyCode = "CompanyCode3",
                    CompanyName = "CompanyName3",
                });

            modelBuilder.Entity<ArSubledger>().HasData(
                new ArSubledger()
                {
                    Id = 1,
                    CompanyId = 1,
                    ArSubledgerCode = "ArSubledgerCode1",
                    Active = "Yes"
                },
                new ArSubledger()
                {
                    Id = 2,
                    CompanyId = 1,
                    ArSubledgerCode = "ArSubledgerCode2",
                    Active = "Yes"
                },
                new ArSubledger()
                {
                    Id = 3,
                    CompanyId = 2,
                    ArSubledgerCode = "ArSubledgerCode3",
                    Active = "Yes"
                },
                new ArSubledger()
                {
                    Id = 4,
                    CompanyId = 2,
                    ArSubledgerCode = "ArSubledgerCode4",
                    Active = "Yes"
                });

            modelBuilder.Entity<Employee>().HasData(

                new Employee()
                {
                    Id = 1,
                    CompanyId = 1,
                    EmployeeCode = "EmployeeCode1"
                },
                new Employee()
                {
                    Id = 2,
                    CompanyId = 1,
                    EmployeeCode = "EmployeeCode2"
                },
                new Employee()
                {
                    Id = 3,
                    CompanyId = 2,
                    EmployeeCode = "EmployeeCode3"
                },
                new Employee()
                {
                    Id = 4,
                    CompanyId = 2,
                    EmployeeCode = "EmployeeCode4"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
