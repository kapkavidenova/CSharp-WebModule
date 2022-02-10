using System.Linq;

using Git.Data;
using Git.Data.Models;
using Git.Models.Repositories;
using Git.Services;

using MyWebServer.Controllers;
using MyWebServer.Http;

using static Git.Data.DataConstants;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {

            var repositoriesQuery = this.data
                .Repositories
                .Where(r => r.IsPublic)
                .Select(r => new RepositoryListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToShortDateString(),
                    Commits = r.Commits.Count()
                })
                .ToList();

            return View(repositoriesQuery);
        }

        [Authorize]
        public HttpResponse Create() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepositoryFormModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == RepositoryPublicType,
                OwnerId = this.User.Id
            };

            this.data.Repositories.Add(repository);
            this.data.SaveChanges();
            return Redirect("/Repositories/Al");
        }
    }
}

