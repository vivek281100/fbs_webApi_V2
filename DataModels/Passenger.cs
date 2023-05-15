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
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }


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

        public List<Booking>?  booking { get; set; }


        //flight relation
        //[ForeignKey("Flight")]
        //public int FlightId { get; set; }

        //public virtual Flight Flight { get; set; }
    }


}
