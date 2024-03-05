﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specify that the value is generated by the database
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
