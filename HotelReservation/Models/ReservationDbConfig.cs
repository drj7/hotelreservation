
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace HotelReservation.Models
{
    public class ReservationDbConfig : DropCreateDatabaseIfModelChanges<ReservationDbContext>
    {
        protected override void Seed(ReservationDbContext context)
        {
            context.ReservationSet.AddOrUpdate(x => x.Name, new[]
            {
                new Reservation
                {
                    Name = "John Miller",
                    NumberOfPersons = 2,
                    RoomType = "Deluxe"
                }


            });
            //base.Seed(context);
        }
    }
}