using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        public string UserId { get; init; }

        [ForeignKey(nameof(UserId))]
        public User User { get; init; }

        public string TripId { get; init; }

        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; init; }
    }
}
