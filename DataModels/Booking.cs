using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fbs_webApi_v2.DataModels
{
    public class Booking
    {
        [Key]
        public int Booking_Id { get; set; }

        //public int BookingId { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public int PaymentId { get; set; }



        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }
        public Payment Payment { get; set; }
        public ICollection<SeatAllocated> seatAllocated { get; set; }



    }
}
