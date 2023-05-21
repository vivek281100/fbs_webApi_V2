using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace fbs_webApi_v2.DataModels
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Flight_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Flight_code { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartureAirportName { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartureAirportCode { get; set; }


        [Required]
        [StringLength(50)]
        public string ArriavalAirportName { get; set; }

        [Required]
        [StringLength(50)]
        public string ArraiavalAirportCode { get; set; }


        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
     
        public DateTime ArrivalDate { get; set; }

        [Required]
        public string DepartureCity { get; set; }

        [Required]
        [StringLength(50)]
        public string ArrivalCity { get; set; }

        [Required]
    
        public DateTime DepartureTime { get; set; }

        [Required]
       
        public DateTime ArrivalTime { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        public int TotalNoofseats { get; set; }

        [Required]
        public bool Isrunning { get; set; } = true;


        //relation to other models
        public IEnumerable<Booking> Bookings { get; set; }
        //public List<Passenger>? flightpassengers { get; set; } 


    }
}
