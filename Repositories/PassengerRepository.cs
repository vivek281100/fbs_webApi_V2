using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.IRepositories;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;

namespace fbs_webApi_v2.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        public Task<Passenger> AddPassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public Task DeletePassangerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Passenger>> GetAllPassengersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Passenger>> GetPassengersByGenderAsunc(string gender)
        {
            throw new NotImplementedException();
        }

        public Task<Passenger> GetPassengersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Passenger> UpdatePassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
