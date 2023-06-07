using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;
using fbs_webApi_v2.DTOs.passengerDtos;
using System.Security.Claims;
using AutoMapper;

namespace fbs_webApi_v2.services.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {

        private readonly fbscontext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PassengerRepository(fbscontext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        //getting user id
        #region Get user id
        private int GetUserId()
        {
            var id =  _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
        #endregion
        
        
        //adduser
        #region Add Passenger
        public async Task<serviceResponce<List<GetPassengerDto>>> AddPassengerAsync(AddPassengerDto addpassenger)
        {
            var passengerAdd = await _context.passengers.FirstOrDefaultAsync(p => p.UserId == GetUserId());

            var responce = new serviceResponce<List<GetPassengerDto>>();

            Passenger passenger = _mapper.Map<Passenger>(addpassenger);
            passenger.UserId = GetUserId();
           
            passenger.booking = await _context.Bookings.FirstOrDefaultAsync(B => B.Id == addpassenger.BookingId);

            passenger.BookingId = passenger.booking.Id;

            passenger.User = await _context.users.FirstOrDefaultAsync(u => u.Id == GetUserId());


            try
            {
                _context.passengers.Add(passenger);

                await _context.SaveChangesAsync();

                responce.Data = await _context.passengers
                    .Where(p => p.BookingId == addpassenger.BookingId)

                .Select(p => _mapper.Map<GetPassengerDto>(p)).ToListAsync();

            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.Success = false;
            }

            return responce;
        }
        #endregion

        //pending....
        #region Delete Passenger
        public async Task<serviceResponce<List<GetPassengerDto>>> DeletePassangerAsync(int id)
        {
            var responce = new serviceResponce<List<GetPassengerDto>>();
            try
            {

                Passenger passenger = await _context.passengers.FirstOrDefaultAsync(p => p.Id == id);
                if (passenger != null)
                {
                    _context.passengers.Remove(passenger);
                    await _context.SaveChangesAsync();

                    responce.Success = true;
                    responce.Data = await _context.passengers.Select(p => _mapper.Map<GetPassengerDto>(p)).ToListAsync();
                    responce.Message = "Passenger Deleted";

                }
                else
                {
                    responce.Success= false;
                    responce.Message = "list empty";
                }
                return responce;
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        #endregion



        //gets all passengers

         
        #region Gets Passengers
        public async Task<serviceResponce<List<GetPassengerDto>>> GetAllPassengersAsync()
        {
            var responce = new serviceResponce<List<GetPassengerDto>>();
            var passengerlist = await _context.passengers.ToListAsync();

            if (passengerlist.Count != 0)
            {
                responce.Message = "passengers reterived";
                responce.Data = _mapper.Map<List<GetPassengerDto>>(passengerlist);
                return responce;
            }

            responce.Success = false;
            responce.Message = "no passengers";
            return responce;
        }
        #endregion

        //gets all passengers by gender
        //done
        //admin use
        #region passenger by gender
        public async Task<serviceResponce<List<GetPassengerDto>>> GetPassengersByGenderAsunc(string gender)
        {
            var responce = new serviceResponce<List<GetPassengerDto>>();
            var passengerlist = await _context.passengers.Where(p => p.Gender == gender).ToListAsync();

            //var passengerlistbygender = passengerlist.Where(p => p.Gender == gender);
            if (passengerlist != null)
            {
                responce.Data = _mapper.Map<List<GetPassengerDto>>(passengerlist);
                responce.Message = "passengers retrived";
                return responce;
            }
            responce.Success = false;
            responce.Message = "no entries";
            return responce;
        }
        #endregion

        //gets passengers by bookingid
        //done
        #region passenders by booking id
        public async Task<serviceResponce<List<GetPassengerDto>>> GetPassengersByBookingIdAsync(int id)
        {
            var responce = new serviceResponce<List<GetPassengerDto>>();
            var passengerlist = await _context.passengers.Where(p => p.BookingId == id).ToListAsync();
            if (passengerlist.Count == 0 || passengerlist == null)
            {
                responce.Success = false;
                responce.Message = "this is a draft booking , click add passengers to see here";
                return responce;
            }
            responce.Data = _mapper.Map<List<GetPassengerDto>>(passengerlist);
            responce.Message = "Passengers retrived";
            return responce;

        }
        #endregion

        //updates user
        //done
        #region Update Passenger
        public async Task<serviceResponce<GetPassengerDto>> UpdatePassengerAsync(UpdatePassengerDto passengerupdate)
        {
            var responce = new serviceResponce<GetPassengerDto>();

            try
            {
                var updatepassenger = await _context.passengers
                        .FirstOrDefaultAsync(p => p.Id == passengerupdate.Passenger_Id);

                if (updatepassenger != null)
                {

                    _mapper.Map(passengerupdate, updatepassenger);

                    //passenger.FirstName = passengerupdate.FirstName;
                    //passenger.LastName = passengerupdate.LastName;
                    //passenger.PhoneNumber = passengerupdate.PhoneNumber;
                    //passenger.Age = passengerupdate.Age;
                    //passenger.Email = passengerupdate.Email;
                    //passenger.Gender = passengerupdate.Gender;
                    //passenger.flight_id = passengerupdate.flight_id;

                    await _context.SaveChangesAsync();
                    responce.Data = _mapper.Map<GetPassengerDto>(updatepassenger);
                    responce.Message = "update successful";

                }
                else
                {
                    responce.Success = false;
                    responce.Message = "passenger not found";
                }
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Message = ex.Message;
            }

            return responce;
        }
        #endregion
    }
}
