using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace JonasCodingTestNet6.API.Entities
{
    [Index(nameof(EmployeeCode), IsUnique = true)]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("CompanyId")]
        //public Company? Company { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public string? Occupation { get; set; }
        public string? EmployeeStatus { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public DateTime? LastModified { get; set; }
    }
}