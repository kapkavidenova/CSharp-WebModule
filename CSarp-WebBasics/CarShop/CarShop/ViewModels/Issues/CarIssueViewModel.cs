using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    internal class CarIssueViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public bool UserIsMechanic { get; set; }

        public IEnumerable<IssueListingViewModel> Issues { get; set; }
    }
}
