using Andreys.Models.Products;
using Andreys.Models.Users;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateProduct(ProductAddViewModel model);

    }
}
