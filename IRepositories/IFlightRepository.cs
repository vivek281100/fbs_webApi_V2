using System;
using fbs_webApi_v2.DataModels;


namespace fbs_webApi_v2.IRepositories
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlightsAsync();

        Task<Flight> GetFlightByIdAsync(int id);

        Task<bool> AddFlight(Flight flight);

        Task<bool> UpdateFlight(Flight flight);
        Task<bool> DeleteFlightByIdAsync(int id);
    }
}
