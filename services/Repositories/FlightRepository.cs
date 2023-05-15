﻿using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;
using fbs_webApi_v2.DTOs.FlightDtos;
using AutoMapper;
using fbs_webApi_v2.DTOs.UserDtos;

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


        //adding flight
        //allowed by admin, no user access.
         public async Task<serviceResponce<List<GetFlightDto>>> AddFlightAsync(AddFlightDto addflight)
        {
            var response = new serviceResponce<List<GetFlightDto>>();

            //var checkuser = _context.Flights.FirstOrDefaultAsync(a => a.Flight_Id == flight.Flight_Id);

            try
            {
                var checkflight = await _context.Flights.FirstOrDefaultAsync(f => f.Flight_Name == addflight.Flight_Name);
                if (checkflight == null)
                {


                    _context.Flights.Add(_mapper.Map<Flight>(addflight));
                    await _context.SaveChangesAsync();

                    response.Message = "flight Added";
                    response.Data = await _context.Flights.Select(f => _mapper.Map<GetFlightDto>(f)).ToListAsync();
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


        //deletes a flight
        //admin access only.
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


        //gets all flights , used to display initial list of flights
        //for admin use.
        public async Task<serviceResponce<List<GetFlightDto>>> GetAllFlightsAsync()
        {
            var responce = new serviceResponce<List<GetFlightDto>>();
            var flights = _context.Flights.ToListAsync();
            if (flights != null)
            {
                responce.Data = _mapper.Map<List<GetFlightDto>>(flights).ToList();
            }
            responce.Success = false;
            responce.Message = "Add Flights to see here";
            return responce;
        }


        //get flight by flight id;
        //to search.
        //admin use
        //need to add error handling.
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


        //for admin , no user access.
        //updates the flight.
        //need to add error handling.
        public async Task<serviceResponce<GetFlightDto>> UpdateFlightAsync(UpdateFlightDto Updateflight)
        {
            var responce = new serviceResponce<GetFlightDto>();

            var checkflight = await _context.Flights.FindAsync(Updateflight.Flight_Id);
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

            return responce;
        }
    }
}
