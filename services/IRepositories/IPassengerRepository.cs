using System;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.passengerDtos;

namespace fbs_webApi_v2.services.IRepositories
{
    public interface IPassengerRepository
    {
        Task<serviceResponce<List<GetPassengerDto>>> GetAllPassengersAsync();

        Task<serviceResponce<List<GetPassengerDto>>> GetPassengersByuserIdAsync();

        Task<serviceResponce<List<GetPassengerDto>>> GetPassengersByGenderAsunc(string gender);

        Task<serviceResponce<List<GetPassengerDto>>> AddPassengerAsync(AddPassengerDto addpassenger);

        Task<serviceResponce<GetPassengerDto>> UpdatePassengerAsync(UpdatePassengerDto updatepassenger);

        Task<serviceResponce<List<GetPassengerDto>>> DeletePassangerAsync(int id);

    }
}
