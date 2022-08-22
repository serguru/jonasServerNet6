namespace JonasCodingTestNet6.API.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public string? Occupation { get; set; }
        public string? EmployeeStatus { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public DateTime? LastModified { get; set; }
    }
}