using System;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.FlightDtos;


namespace fbs_webApi_v2.services.IRepositories
{
    public interface IFlightRepository
    {
        Task<serviceResponce<List<GetFlightDto>>> GetAllFlightsAsync();

        Task<serviceResponce<GetFlightDto>> GetFlightByIdAsync(int id);

        Task<serviceResponce<List<GetFlightDto>>> SearchFlights(SearchFlightDto searchflight);
        Task<serviceResponce<List<GetFlightDto>>> AddFlightAsync(AddFlightDto addflight);

        Task<serviceResponce<GetFlightDto>> UpdateFlightAsync(UpdateFlightDto updateflight);
        Task<serviceResponce<GetFlightDto>> DeleteFlightByIdAsync(int id);
    }
}
