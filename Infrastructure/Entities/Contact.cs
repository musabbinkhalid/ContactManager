using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ContactManager.Infrastructure.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [StringLength(50)]
        public string Phone { get; set; } = string.Empty;
        [RegularExpression(pattern: @"^[#.0-9a-zA-Z\s-*,'&','/']+$", ErrorMessage = "No special characters are allowed except &,/# characters")]
        [StringLength(1000)]
        public string Address { get; set; } = string.Empty;
        [StringLength(100)]
        public string City { get; set; } = string.Empty;
        [StringLength(100)]
        public string Region { get; set; } = string.Empty;
        [StringLength(100)]
        public string PostalCode { get; set; } = string.Empty;
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;

    }
}
