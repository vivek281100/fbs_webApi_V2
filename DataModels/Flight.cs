using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace fbs_webApi_v2.DataModels
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Flight_Id { get; set; }

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
        [DataType(DataType.Date)]
        public string DepartureDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string ArrivalDate { get; set; }

        [Required]
        public string DepartureCity { get; set; }

        [Required]
        [StringLength(50)]
        public string ArrivalCity { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string DepartureTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string ArrivalTime { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        public int TotalNoofseats { get; set; }


        //public IEnumerable<Passenger>  passengers { get; set; }
    }
}
