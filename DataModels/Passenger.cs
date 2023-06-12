using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fbs_webApi_v2.DataModels
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;


        [Required]
        [Range(18, 100)]
        public int Age { get; set; }


        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [Required]
        [StringLength(120)]
        public string Email { get; set; }


        [Required]
        [StringLength(13)]
        public string PhoneNumber { get; set; }

        [Required]
        public string AllocatedSeat { get; set; }


        //flight relation
        //[ForeignKey("Flight")]
        //public int FlightId { get; set; }

        //public virtual Flight Flight { get; set; }

        public int UserId { get; set; }

        public int BookingId { get; set; }


        public User User { get; set; }

        public Booking booking { get; set; }
    }


}
