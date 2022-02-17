using Andreys.Data;
using Andreys.Models;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace Andreys.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext data;

        public HomeController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {
            return this.View();
        }

        [Authorize]
        public HttpResponse Home()
        {
            var products = data.Products
                .Select(p => new HomeViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price.ToString("F2"),
                })
                .ToList();

            return this.View(products);
        }
    }
}
