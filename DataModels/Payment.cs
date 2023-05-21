using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace fbs_webApi_v2.DataModels
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Payment_DateTime { get; set; } = DateTime.Now;

        [Required]
        [StringLength(100)]
        public string Payment_Mode { get; set; }

        [Required]
        public decimal Total_Price { get; set; }

        [Required]
        public bool PaymentStatus { get; set; }


        //one to one with booking table
        //public int bookingid { get; set; }

        //[ForeignKey(nameof(bookingid))]
        //public Booking? booking {get; set; }

        public int bookingid { get; set; }

        public Booking booking { get; set; }
        
    }
}
