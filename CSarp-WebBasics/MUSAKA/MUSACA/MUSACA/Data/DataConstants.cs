using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSACA.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 36;
        public const int NameMaxLength = 128;
        public const int PasswordMaxLength = 128;


        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string UserRole = "User";
        public const string AdminRole = "Role";
        public const string BarcodeRegularExpression = @"^([0-9]{12})$";
        public const string ActiveStatus = "Sratus";
        public const string CompletedStatus = "Completed";

    }
}
