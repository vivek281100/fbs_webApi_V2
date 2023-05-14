using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;

namespace fbs_webApi_v2.services.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {

        private readonly fbscontext _context;

        public PassengerRepository(fbscontext context)
        {
            _context = context;
        }

        public async Task<bool> AddPassengerAsync(Passenger passenger)
        {
            var passengerAdd = await _context.passengers.FirstOrDefaultAsync(p => p.Passenger_Id == passenger.Passenger_Id);
            if (passengerAdd == null)
            {
                await _context.passengers.AddAsync(passenger);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }


        public async Task<bool> DeletePassangerAsync(int id)
        {
            var passenger = await _context.passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.passengers.Remove(passenger);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IAsyncEnumerable<Passenger>> GetAllPassengersAsync()
        {
            var passengerlist = _context.passengers.AsAsyncEnumerable<Passenger>();
            return passengerlist;
        }

        public async Task<List<Passenger>> GetPassengersByGenderAsunc(string gender)
        {
            var passengerlistbygender = await _context.passengers.Where(p => p.Gender == gender).ToListAsync();
            return passengerlistbygender;
        }

        public async Task<Passenger?> GetPassengersByIdAsync(int id)
        {
            var passenger = await _context.passengers.FindAsync(id);
            return passenger;


        }

        public async Task<bool> UpdatePassengerAsync(Passenger passengerupdate)
        {
            var passenger = await _context.passengers.FindAsync(passengerupdate.Passenger_Id);
            if (passenger != null)
            {
                passenger.FirstName = passengerupdate.FirstName;
                passenger.LastName = passengerupdate.LastName;
                passenger.PhoneNumber = passengerupdate.PhoneNumber;
                passenger.Age = passengerupdate.Age;
                passenger.Email = passengerupdate.Email;
                passenger.Gender = passengerupdate.Gender;
                //passenger.flight_id = passengerupdate.flight_id;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
