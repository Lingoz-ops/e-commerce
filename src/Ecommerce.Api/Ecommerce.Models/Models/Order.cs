﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is generated by the database
        public string? Id { get; set; }
        public bool Paid { get; set; }
        public string? CustomerId { get; set; } // Make CustomerId nullable
        //public ICollection<OrderProduct> OrderProducts { get; set; }
        public decimal Total { get; set; }
    }
}