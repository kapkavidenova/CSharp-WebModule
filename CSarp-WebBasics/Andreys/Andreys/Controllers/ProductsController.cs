using Andreys.Data;
using Andreys.Data.Models;
using Andreys.Models.Products;
using Andreys.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Linq;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public ProductsController(
            IValidator validator,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }
        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(ProductAddViewModel model)
        {
            var modelErrors = this.validator.ValidateProduct(model);
            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Category = Enum.Parse<Category>(model.Category),
                Gender = Enum.Parse<Gender>(model.Gender),
                Price = model.Price
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();
            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Details(string id)
        {
            var product = this.data.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductAddViewModel
                {
                    Id =p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Gender = p.Gender.ToString(),
                    Price = p.Price,
                    Category = p.Category.ToString()

                })
                .FirstOrDefault();

            return View(product);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var product = this.data.Products
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (product == null)
            {
                return BadRequest();
            }

            this.data.Products.Remove(product);
            this.data.SaveChanges();
            return Redirect("/ Home/Home");
        }
    }
}
