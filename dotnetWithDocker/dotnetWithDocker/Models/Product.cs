﻿using System.ComponentModel.DataAnnotations;

namespace dotnetWithDocker.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }



    }
}
