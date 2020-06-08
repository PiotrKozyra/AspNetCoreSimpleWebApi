using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WholesaleApi.Models {
    public class Product {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int? CategoryId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int? SupplierId { get; set; }

        public int QuantityPerUnit { get; set; }

        public float UnitPrice { get; set; }

        public int UnitInStock { get; set; }

        public int UnitOnOrder { get; set; }

        [JsonIgnore]
        public Supplier Supplier { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }

    }
}