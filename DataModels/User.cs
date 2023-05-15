using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace fbs_webApi_v2.DataModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string User_Name { get; set; }


        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(120)]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        
        //public int bookingid { get; set; }

        //[ForeignKey("bookingid")]
        //public List<Booking>? Bookings { get; set; }
        //public List<Passenger>? passengers { get; set; }

   


    }
}
