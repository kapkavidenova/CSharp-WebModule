using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Data.Models
{
    public class User
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; init; }

        public IEnumerable<UserTrip> UserTrips { get; init; } = new List<UserTrip>();
    }
}
