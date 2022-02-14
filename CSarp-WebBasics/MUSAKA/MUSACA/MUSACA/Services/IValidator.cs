using MUSACA.ViewModels.Users;
using System.Collections.Generic;

namespace MUSACA.Services
{


    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        //ICollection<string> ValidateRepository(CreateRepositoryFormModel model);
    }
}
