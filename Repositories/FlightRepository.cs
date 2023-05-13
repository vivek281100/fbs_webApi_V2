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
        private readonly fbscontext _context;

        public FlightRepository(fbscontext context)
        {
            _context = context;
        }

        public async Task<bool> AddFlight(Flight flight)
        {
            var checkuser = _context.Flights.FirstOrDefaultAsync(a => a.Flight_Id == flight.Flight_Id);
            if (checkuser == null)
            {
                await _context.Flights.AddAsync(flight);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteFlightByIdAsync(int id)
        {
            var userdelete = await _context.Flights.FindAsync(id);
            if (userdelete != null)
            {
                _context.Flights.Remove(userdelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<Flight> GetFlightByIdAsync(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if(flight == null)
            {
                return null;
            }

            return flight;
        }

        public async Task<bool> UpdateFlight(Flight flight)
        {
            var checkflight = await _context.Flights.FindAsync(flight.Flight_Id);
            if(checkflight == null) 
            {
                checkflight.Flight_Name = flight.Flight_Name;
                checkflight.Flight_code = flight.Flight_code;
                checkflight.DepartureAirportName = flight.DepartureAirportName;
                checkflight.DepartureAirportCode = flight.DepartureAirportCode;
                checkflight.ArriavalAirportName = flight.ArriavalAirportName;
                checkflight.ArraiavalAirportCode = flight.ArraiavalAirportCode;
                checkflight.DepartureDate = flight.DepartureDate;
                checkflight.ArrivalDate = flight.ArrivalDate;
                checkflight.DepartureTime = flight.DepartureTime;
                checkflight.ArrivalTime = flight.ArrivalTime;
                checkflight.DepartureCity = flight.DepartureCity;
                checkflight.ArrivalCity = flight.ArrivalCity;
                checkflight.BasePrice = flight.BasePrice;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
