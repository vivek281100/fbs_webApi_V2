using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fbs_webApi_v2.DTOs.FlightDtos
{
    public class GetFlightDto
    {
        public int Id { get; set; }
        public string Flight_Name { get; set; }

        public string Flight_code { get; set; }


        public string DepartureAirportName { get; set; }


        public string DepartureAirportCode { get; set; }



        public string ArriavalAirportName { get; set; }


        public string ArraiavalAirportCode { get; set; }



        public DateTime DepartureDate { get; set; }


        public DateTime ArrivalDate { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }


        public DateTime DepartureTime { get; set; }


        public DateTime ArrivalTime { get; set; }


        public decimal BasePrice { get; set; }

        public int TotalNoofseats { get; set; }

        public bool Isrunning { get; set; }
    }
}
