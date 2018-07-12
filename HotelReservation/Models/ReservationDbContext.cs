
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class ReservationDbContext : DbContext
    {
        public DbSet<Reservation> ReservationSet { get; set; }
    }
}