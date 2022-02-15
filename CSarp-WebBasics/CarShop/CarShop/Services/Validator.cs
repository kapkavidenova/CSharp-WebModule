using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;
using CarShop.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static CarShop.Data.DataConstants;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
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
        public ICollection<string> ValidateCar(AddCarViewModel car)
        {
            var errors = new List<string>();

            if (car.Model == null || car.Model.Length < ModelMinName || car.Model.Length > DefaultMaxLength)
            {
                errors.Add($"Model '{car.Model}' is not valid. It must be between {ModelMinName} and {DefaultMaxLength} characters long.");
            }

            if (car.Year < CarYearMinValue || car.Year > CarYearMaxValue)
            {
                errors.Add($"Year '{car.Year}' is not valid. It must be between {CarYearMinValue} and {CarYearMaxValue}.");
            }

            if (car.Image == null || !Uri.IsWellFormedUriString(car.Image, UriKind.Absolute))
            {
                errors.Add($"Image '{car.Image}' is not valid. It must be a valid URL.");
            }

            if (car.PlateNumber == null || !Regex.IsMatch(car.PlateNumber, PlateNumberRegularExpression))
            {
                errors.Add($"Plate number '{car.PlateNumber}' is not valid. It should be in 'XX0000XX' format.");
            }

            return errors;
        }
        public ICollection<string> ValidateIssue(AddIssueFormModel issue)
        {
            var errors = new List<string>();

            if (issue.CarId == null)
            {
                errors.Add($"Car ID cannot be empty.");
            }

            if (issue.Description.Length < IssueMinDescription)
            {
                errors.Add($"Description '{issue.Description}' is not valid. It must have more than {IssueMinDescription} characters.");
            }

            return errors;
        }
    }
}
