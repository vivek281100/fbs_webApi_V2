using System;
using fbs_webApi_v2.DataModels;


namespace fbs_webApi_v2.IRepositories
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlightsAsync();

        Task<Flight> GetFlightByIdAsync(int id);

        Task<Flight> AddFlight(Flight flight);

        Task<Flight> UpdateFlight(Flight flight);
        Task DeleteFlightByIdAsync(int id);
    }
}
