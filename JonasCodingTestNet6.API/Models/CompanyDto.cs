﻿using JonasCodingTestNet6.API.Entities;

namespace JonasCodingTestNet6.API.Models
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EquipmentCompanyCode { get; set; }
        public string Country { get; set; }
        public DateTime LastModified { get; set; }
    }
}
