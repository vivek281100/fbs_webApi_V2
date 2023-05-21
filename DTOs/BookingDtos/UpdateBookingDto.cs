using System.ComponentModel.DataAnnotations;

namespace fbs_webApi_v2.DTOs.BookingDtos
{
    public class UpdateBookingDto
    {
        public bool status { get; set; } = false;

    
        public DateTime bookingdatetime { get; set; } = DateTime.Now;

        public int FlightId { get; set; }
    }
}
