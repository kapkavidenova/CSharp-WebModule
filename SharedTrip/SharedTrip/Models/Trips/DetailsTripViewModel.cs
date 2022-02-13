using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models.Trips
{
    public class DetailsTripViewModel
    {
        public string Id { get; set; }
        public string StartPoint { get; init; }

        public string EndPoint { get; init; }

        public int Seats { get; set; }

        public string Description { get; init; }

        public string DepartureTime { get; init; }

        public string ImagePath { get; init; }


    }
}
