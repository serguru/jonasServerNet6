using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JonasCodingTestNet6.API.Entities
{
    [Index(nameof(CompanyCode), IsUnique = true)]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CompanyCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? PostalZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? EquipmentCompanyCode { get; set; }
        public string? Country { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
