﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is generated by the database
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public ICollection<OrderProduct> OrderProducts { get; set; } // Navigation property
    }
}
