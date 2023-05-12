using System;
using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.IRepositories
{
    public interface IPassengerRepository
    {
        Task<IAsyncEnumerable<Passenger>> GetAllPassengersAsync();

        Task<Passenger> GetPassengersByIdAsync(int id);

        Task<List<Passenger>> GetPassengersByGenderAsunc(string gender);

        Task<bool> AddPassengerAsync(Passenger passenger);

        Task<bool> UpdatePassengerAsync(Passenger passenger);

        Task<bool> DeletePassangerAsync(int id);

    }
}
