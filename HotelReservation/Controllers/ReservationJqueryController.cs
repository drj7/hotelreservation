using HotelReservation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class ReservationJqueryController : Controller
    {
        private ReservationDbContext db = new ReservationDbContext();

        // GET: ReservationJquery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display() {

            var results = db.ReservationSet.OrderBy(x => x.Name).ToList();
           
            //return Content(results, "application/json");
            return Content(JsonConvert.SerializeObject(results));
        }

        public ActionResult Check(CheckReservationFormModel form)
        {

            
          /*  if (ModelState.IsValid)
            {
                var reserv = new Reservation
                {
                    CheckInDate = form.CheckInDate,
                    CheckOutDate = form.CheckOutDate,
                    RoomType= form.RoomType
                };
                db.ReservationSet.Add(reserv);
                db.SaveChanges();
                return Content(JsonConvert.SerializeObject(reserv));
            }*/

            if (ModelState.IsValid)
            {

                var results = from reservation in db.ReservationSet
                              where (form.CheckInDate >= reservation.CheckInDate) &&
                               (form.CheckOutDate <= reservation.CheckOutDate || (form.CheckOutDate > reservation.CheckOutDate && !(form.CheckInDate >= reservation.CheckInDate))) &&
                              (form.RoomType.Equals(reservation.RoomType))
                              select reservation;

                var reserv = new Reservation
                {
                    CheckInDate = form.CheckInDate,
                    CheckOutDate = form.CheckOutDate,
                    RoomType = form.RoomType,
                    Count = results.Count()
                };


                return Content(JsonConvert.SerializeObject(reserv));
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
        }
    }
}