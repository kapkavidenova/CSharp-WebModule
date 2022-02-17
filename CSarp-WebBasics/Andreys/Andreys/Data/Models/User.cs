using System;
using System.ComponentModel.DataAnnotations;

using static Andreys.Data.DataConstants;

namespace Andreys.Data.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
