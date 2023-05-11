using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace fbs_webApi_v2.DataModels
{
    public class Flight
    {
        [Key]
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
        public DateTime DepartureDateTime { get; set; }

        [Required]
        public DateTime ArrivalDateTime { get; set; }

        [Required]
        public string DipartureCityCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ArrivalCityCode { get; set; }

        [Required]
        public decimal BasePrice { get; set; }


        public IEnumerable<Passenger>  passengers { get; set; }
    }
}
