using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSACA.Data.Models
{
    public class Order
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Status { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public User Cashier { get; set; }

        public string UserId { get; set; }
    }
}
