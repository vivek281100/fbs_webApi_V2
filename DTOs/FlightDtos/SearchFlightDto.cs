namespace fbs_webApi_v2.DTOs.FlightDtos
{
    public class SearchFlightDto
    {
        public string DepartureCity { get; set; } = string.Empty;

        public string ArrivalCity { get; set; } = string.Empty;

        public DateTime DepartureDate { get; set; } 
    }
}
