using MUSACA.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MUSACA.Services
{


    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            //if (model.Id.Length < IdMaxLength)
            //{
            //    errors.Add($"Id '{model.Id}' is not valid. It must be less than {IdMaxLength} characters long.");
            //}

            if (model.Username.Length > NameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be  less than {NameMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if ( model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be less than {PasswordMaxLength} characters long.");
            }
            
            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

      

        //public ICollection<string> ValidateRepository(CreateRepositoryFormModel model)
        //{
        //    var errors = new List<string>();

        //    if (model.Name.Length < RepositoryMinName || model.Name.Length > RepositoryMaxName)
        //    {
        //        errors.Add($"Repository '{model.Name}' is not valid. It must be between {RepositoryMinName} and {RepositoryMinName} characters long.");
        //    }

        //    if (model.RepositoryType != RepositoryPublicType && model.RepositoryType != RepositoryPrivateType)
        //    {
        //        errors.Add($"Repository type can be either '{RepositoryPublicType}' or '{RepositoryPrivateType}'.");
        //    }

        //    return errors;
        //}
    }
}
