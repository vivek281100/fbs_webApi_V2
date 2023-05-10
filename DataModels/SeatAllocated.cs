using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fbs_webApi_v2.DataModels
{
    public class SeatAllocated
    {
        [Key]
        public int Seat_Id { get; set; }

        [Required]
        public bool Seat_Allocated { get; set; }

        [Required]
        public string SeatNumber { get; set; }
    
       
    }
}
