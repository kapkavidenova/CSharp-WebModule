using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int DefaultMaxLength = 20;

        public const int UserMinUsername = 4;
        public const int UserMinPassword = 5;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int ModelMinName = 5;
        //public const int ModelMaxName = 20;//default=20
        //public const string RepositoryPublicType = "Public";
        // public const string RepositoryPrivateType = "Private";

        public const int CarYearMinValue = 1900;
        public const int CarYearMaxValue = 2022;

        public const int IssueMinDescription = 5;

        public const int PlateNumberMaxLength = 8;
        public const string PlateNumberRegularExpression = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
    }
}
