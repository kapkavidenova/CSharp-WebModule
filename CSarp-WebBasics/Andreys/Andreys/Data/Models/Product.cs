using System;
using System.ComponentModel.DataAnnotations;

using static Andreys.Data.DataConstants;

namespace Andreys.Data.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();


        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Name { get; set; }


        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Gender Gender { get; set; }

    }
}
