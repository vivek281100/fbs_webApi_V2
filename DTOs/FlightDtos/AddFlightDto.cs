namespace fbs_webApi_v2.DTOs.FlightDtos
{
    public class AddFlightDto
    {
        public int FlightId { get; set; }
        public string Flight_Name { get; set; }

        public string Flight_code { get; set; }


        public string DepartureAirportName { get; set; }


        public string DepartureAirportCode { get; set; }



        public string ArriavalAirportName { get; set; }


        public string ArraiavalAirportCode { get; set; }



        public string DepartureDate { get; set; }


        public string ArrivalDate { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }


        public string DepartureTime { get; set; }


        public string ArrivalTime { get; set; }


        public decimal BasePrice { get; set; }

        public int TotalNoofseats { get; set; }

        public bool Isrunning { get; set; } = true;
    }
}
