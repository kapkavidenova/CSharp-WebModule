using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SharedTrip.Data
{
    public class DataConstants
    {
        public const int DefaultMaxLength = 20;
        public const int UserMinUsername = 5;
        public const int PasswordMaxLength = 64;
        public const int UserMinPassword = 6;


        public const int SeatsMinNumber = 2;
        public const int SeatsMaxNumber = 6;

        public const int DescriptionMaxLength = 80;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    }
}
