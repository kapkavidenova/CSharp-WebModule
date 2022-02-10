using System.Linq;

using Git.Data;
using Git.Data.Models;
using Git.Models.Commits;

using MyWebServer.Controllers;
using MyWebServer.Http;

using static Git.Data.DataConstants;

namespace Git.Controllers
{
    public class CommitsController:Controller
    {
            private readonly ApplicationDbContext data;

        public CommitsController(ApplicationDbContext data)
        {
            this.data = data;
        }
        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = this.data.Repositories
                .Where(r => r.Id == id)
                .Select(r => new CommitToRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefault();

            if (repository == null)
            {
                return BadRequest();
            }

            return View(repository);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateViewModel model)
        {
            if (!this.data.Repositories.Any(r => r.Id == model.Id))
            {
                return BadRequest();
            }

            if (model.Description.Length<CommitMinDescription)
            {
                return Error("The length of the description is not properly.");
            }

            var commit = new Commit
            {
                Description = model.Description,
                RepositoryId = model.Id,
                CreatorId = this.User.Id
            };

            this.data.Commits.Add(commit);
            this.data.SaveChanges();

            return Redirect("Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data.Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToLocalTime().ToString("F"),
                    Repository = c.Repository.Name
                })
                .ToList();

            return View(commits);

        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits.Find(id);

            if (commit == null || commit.CreatorId != this.User.Id)
            {
                return BadRequest();
            }
                this.data.Commits.Remove(commit);
                this.data.SaveChanges();

                return Redirect("/Commits/All");
        }
    }
}
