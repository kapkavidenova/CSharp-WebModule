using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSACA.Data.Models
{
    public class Receipt
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime IssuedOn { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public string UserId { get; set; }

        public User Cashier { get; set; }

    }
}
