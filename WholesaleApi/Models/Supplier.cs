using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WholesaleApi.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }
    
        public ICollection<Product> Products { get; set; }

    }
}