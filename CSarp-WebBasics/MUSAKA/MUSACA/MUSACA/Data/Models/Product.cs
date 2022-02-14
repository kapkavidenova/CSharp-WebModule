using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSACA.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Barcode { get; set; }

        public string Picture { get; set; }
    }
}
