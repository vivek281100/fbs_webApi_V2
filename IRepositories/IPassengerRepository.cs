using System;
using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.IRepositories
{
    public interface IPassengerRepository
    {
        Task<List<Passenger>> GetAllPassengersAsync();

        Task<Passenger> GetPassengersByIdAsync(int id);

        Task<List<Passenger>> GetPassengersByGenderAsunc(string gender);

        Task<Passenger> AddPassengerAsync(Passenger passenger);

        Task<Passenger> UpdatePassengerAsync(Passenger passenger);

        Task DeletePassangerAsync(int id);

    }
}
