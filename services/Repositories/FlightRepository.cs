using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;
using fbs_webApi_v2.DTOs.FlightDtos;
using AutoMapper;
using fbs_webApi_v2.DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization;

namespace fbs_webApi_v2.services.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly fbscontext _context;
        private readonly IMapper _mapper;

        public FlightRepository(fbscontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //search flight by from and to
        //accessable by all
        #region search Flight
        public async Task<serviceResponce<List<GetFlightDto>>> SearchFlights(SearchFlightDto searchFlight)
        {
            var responce = new serviceResponce<List<GetFlightDto>>();
            try
            {
                var flights = await _context.Flights
                    .Where(f => f.DepartureCity.ToLower() == searchFlight.DepartureCity.ToLower() && f.ArrivalCity.ToLower() == searchFlight.ArrivalCity.ToLower() && f.DepartureDate.Date == searchFlight.DepartureDate.Date).ToListAsync();

                if (flights == null || flights.Count == 0)
                {
                    responce.Success = false;
                    responce.Message = "No Flights found";


                }
                else
                {
                    responce.Message = "Flights Found";
                    responce.Data = _mapper.Map<List<GetFlightDto>>(flights);
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

        //adding flight
        //allowed by admin, no user access.
        #region add Flight
        public async Task<serviceResponce<List<GetFlightDto>>> AddFlightAsync(AddFlightDto addflight)
        {
            var response = new serviceResponce<List<GetFlightDto>>();

            //var checkuser = _context.Flights.FirstOrDefaultAsync(a => a.Flight_Id == flight.Flight_Id);

            try
            {
                var checkflight = await _context.Flights.FirstOrDefaultAsync(f => f.Flight_code == addflight.Flight_code);
                if (checkflight == null)
                {


                    _context.Flights.Add(_mapper.Map<Flight>(addflight));
                    await _context.SaveChangesAsync();

                    response.Message = "flight Added";
                    response.Data = await _context.Flights.Select(f => _mapper.Map<GetFlightDto>(f)).ToListAsync();
                    return response;
                }

                response.Success = false;
                response.Message = "Flight already exists";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion

        //deletes a flight
        //admin access only.
        #region delete flight
        public async Task<serviceResponce<GetFlightDto>> DeleteFlightByIdAsync(int id)
        {
            var responce = new serviceResponce<GetFlightDto>();
            var flightdelete = await _context.Flights.FindAsync(id);
            if (flightdelete != null)
            {
                _context.Flights.Remove(flightdelete);
                await _context.SaveChangesAsync();

                responce.Data = _mapper.Map<GetFlightDto>(flightdelete);
                responce.Message = "flight deleted";
                return responce;
            }

            responce.Success = false;
            responce.Message = "Flight bot found";
            return responce;
        }
        #endregion

        //gets all flights , used to display initial list of flights
        //for admin use.
        #region get all flights
        public async Task<serviceResponce<List<GetFlightDto>>> GetAllFlightsAsync()
        {
            var responce = new serviceResponce<List<GetFlightDto>>();
            try
            {
                var flights = await _context.Flights.ToListAsync();
                if (flights != null)
                {
                    responce.Data = _mapper.Map<List<GetFlightDto>>(flights);
                    responce.Message = "flights list";
                    return responce;
                }
                responce.Success = false;
                responce.Message = "Add Flights to see here";
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

        //get flight by flight id;
        //to search.
        //admin use
        //need to add error handling.
        #region get flight by id

        public async Task<serviceResponce<GetFlightDto>> GetFlightByIdAsync(int id)
        {
            var responce = new serviceResponce<GetFlightDto>();
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                responce.Success = false;
                responce.Message = "Flight not found";
                return responce;
            }
            responce.Data = _mapper.Map<GetFlightDto>(flight);
            responce.Message = "Flight Found";
            return responce;
        }

        #endregion


        //for admin , no user access.
        //updates the flight.
        //need to add error handling.
        #region update flight
        public async Task<serviceResponce<GetFlightDto>> UpdateFlightAsync(UpdateFlightDto Updateflight)
        {
            var responce = new serviceResponce<GetFlightDto>();

            var checkflight = await _context.Flights.FindAsync(Updateflight.Id);
            if (checkflight != null)
            {
                //checkflight.Flight_Name = flight.Flight_Name;
                //checkflight.Flight_code = flight.Flight_code;
                //checkflight.DepartureAirportName = flight.DepartureAirportName;
                //checkflight.DepartureAirportCode = flight.DepartureAirportCode;
                //checkflight.ArriavalAirportName = flight.ArriavalAirportName;
                //checkflight.ArraiavalAirportCode = flight.ArraiavalAirportCode;
                //checkflight.DepartureDate = flight.DepartureDate;
                //checkflight.ArrivalDate = flight.ArrivalDate;
                //checkflight.DepartureTime = flight.DepartureTime;
                //checkflight.ArrivalTime = flight.ArrivalTime;
                //checkflight.DepartureCity = flight.DepartureCity;
                //checkflight.ArrivalCity = flight.ArrivalCity;
                //checkflight.BasePrice = flight.BasePrice;

                //using mapper.
                _mapper.Map(Updateflight, checkflight);

                await _context.SaveChangesAsync();
                responce.Message = "flight updated";
                return responce;
            }
            responce.Success = false;
            responce.Message = "Flight no found";
            return responce;
        }
        #endregion

        //for user,
        //gets flight details by booking id.
        #region
        public async Task<serviceResponce<GetFlightDto>> getflightdetailsbybookingId(int id)
        {
            var responce = new serviceResponce<GetFlightDto>();
            try
            {
                var booking = await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync();
                if (booking == null)
                {
                    responce.Message = "booking Not Found";
                    responce.Success = false;
                    return responce;
                }
                var flight = await _context.Flights.Where(f => f.Id == booking.FlightId).FirstOrDefaultAsync();
                if (flight == null)
                {
                    responce.Message = "flight not found";
                    responce.Success = false;
                    return responce;
                }

                responce.Success = true;
                responce.Data = _mapper.Map<GetFlightDto>(flight);
                responce.Message = "Flight Found";

                return responce;

            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.Success = false;
                return responce;
            }
        }
        #endregion


        //occupird flight seats
        #region flight seats list
        public async Task<serviceResponce<List<string>>> getOccupiedflightseats(int id)
        {
            var responce = new serviceResponce<List<string>>();

            try
            {
                var flight = await _context.Flights.Where(f => f.Id == id).FirstOrDefaultAsync();
                if (flight == null)
                {
                    responce.Success = false;
                    responce.Message = "Flight not found";
                    return responce;
                }

               // var bookings = flight.Bookings;
                var bookings = await _context.Bookings.Include(p => p.Passenger).Where(b => b.FlightId == id).ToListAsync();
                var passengers = new List<Passenger>();
                foreach (var booking in bookings)
                {
                    foreach (var passengercheck in booking.Passenger)
                    {
                        passengers.Add(passengercheck);

                    }
                }

                var seats = new List<string>();
                foreach (var passenger in passengers)
                {
                    seats.Add(passenger.AllocatedSeat);
                }


                responce.Success = true;
                responce.Message = "seats";
                responce.Data = seats;
                return responce;

            }
            catch (Exception ex) { 
                responce.Success=false;
                responce.Message=ex.Message;
                return responce;
            }
        }
        #endregion
    }
}
