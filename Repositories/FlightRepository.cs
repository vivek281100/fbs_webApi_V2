using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.IRepositories;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;

namespace fbs_webApi_v2.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        public Task<Flight> AddFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFlightByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flight>> GetAllFlightsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Flight> GetFlightByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Flight> UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
