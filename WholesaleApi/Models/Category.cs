using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WholesaleApi.Models {
    public class Category {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}