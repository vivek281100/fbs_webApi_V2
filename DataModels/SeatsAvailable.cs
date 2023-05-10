using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace fbs_webApi_v2.DataModels
{
    public class SeatsAvailable
    {
        [Key]
        public int SeatsAvailable_Id { get; set; }

        [Required]
        public int TotalNoOfSeats { get; set; }

        [Required]
        public int seatsAvailable { get; set; }


       
    }
}
