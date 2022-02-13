using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TripsController(ApplicationDbContext data,IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            var trips = this.data.Trips
                .Select(t => new TripsListingViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    Description = t.Description
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }
            //DateTime date;

            //DateTime.TryParseExact(
            //    model.DepartureTime,
            //    "dd.MM.yyyy HH:mm",
            //    CultureInfo.InvariantCulture,
            //    DateTimeStyles.None,
            //    out date);
        
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime,"dd.MM.yyyy HH:ss",CultureInfo.InvariantCulture),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            if (!this.data.Trips.Where(t=>t.Id == tripId).Any())
            {
                return Error("Trip does not exist.");
            }

            var trip = this.data.Trips
                .Where(t => t.Id == tripId)
                .Select(t => new DetailsTripViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Seats = t.Seats,
                    DepartureTime =t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = t.Description
                })
                .FirstOrDefault();

            return View(trip);
        }


        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {          
            if (!this.data.Trips.Where(t=>t.Id == tripId).Any())
            {
                return Error("Trip does not exist.");
            }

            var trip = this.data.Trips
                .Where(t => t.Id == tripId)               
                .FirstOrDefault();

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = this.User.Id
            };

            if (this.data.UserTrips.Where(t=>t.TripId==tripId && t.UserId == this.User.Id).Any())
            {
                return Error("The user is registered.");
            }

            this.data.UserTrips.Add(userTrip);
           
            this.data.SaveChanges();
            return Redirect("/Trips/All");
        }
      
    }
}
