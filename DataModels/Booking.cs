using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fbs_webApi_v2.DataModels
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

      
        [Required]
        public bool status { get; set; } = false;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime bookingdatetime { get; set; } = DateTime.Now;

        //[ForeignKey("User")]
        //public int UserId { get; set; }

        //[ForeignKey("Flight")]
        //public int FlightId { get; set; }

        //[ForeignKey("Payment")]
        //public int? PaymentId { get; set; }


        ////navgiation properties.
        //public virtual User User { get; set; }


        ////[ForeignKey("FlightId")]
        //public virtual Flight Flight { get; set; }

        ////[ForeignKey("PaymentId")]
        //public Payment? Payment { get; set; }


        //public ICollection<Passenger> Passengers { get; set; }
    }

    
}
