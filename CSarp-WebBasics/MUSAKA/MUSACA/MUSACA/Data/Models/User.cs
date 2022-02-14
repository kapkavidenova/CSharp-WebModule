using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSACA.Data
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        public string Email { get; set; }


        public string Role { get; set; }

    }
}
