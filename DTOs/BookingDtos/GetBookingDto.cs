using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.DTOs.BookingDtos
{
    public class GetBookingDto
    {
        public int? Id { get; set; }
        public bool status { get; set; } = false;


        public DateTime bookingdatetime { get; set; } 

        public int FlightId { get; set; }

        //public Payment? payment { get; set; }
    }
}
