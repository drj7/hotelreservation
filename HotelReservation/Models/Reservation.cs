using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.Models
{
    public class Reservation
    {

        public Reservation()
        {
            CheckInDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomType { get; set; }
        public int NumberOfPersons { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Count { get; set; }
    }
}