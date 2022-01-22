using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        //[Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? ContactName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        //[Required]
        public string? Region { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? Phone { get; set; }
    }
}
