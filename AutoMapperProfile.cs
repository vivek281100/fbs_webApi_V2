
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.AdminDtos;
using fbs_webApi_v2.DTOs.BookingDtos;
using fbs_webApi_v2.DTOs.FlightDtos;
using fbs_webApi_v2.DTOs.passengerDtos;
using fbs_webApi_v2.DTOs.paymentDtos;
using fbs_webApi_v2.DTOs.UserDtos;

namespace fbs_webApi_v2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //admin
            CreateMap<Admin,GetAdminDto>();
            CreateMap<AddAdminDto, Admin>();
            CreateMap<UpdateAdminDto, Admin>();

            //User
            CreateMap<User,GetUserDto>();
            CreateMap<User,GetUserWithoutPasswordDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<updateUserDto, User>();
            CreateMap<userupdateForUserDto, User>();

            //Passenger
            CreateMap<Passenger, GetPassengerDto>();
            CreateMap<AddPassengerDto, Passenger>();
            CreateMap<UpdatePassengerDto, Passenger>();

            //Flights
            CreateMap<Flight, GetFlightDto>();
            CreateMap<AddFlightDto, Flight>();
            CreateMap<UpdateFlightDto, Flight>();
            //CreateMap<SearchFlightDto, Flight>();

            //Booking
            CreateMap<Booking, GetBookingDto>();
            CreateMap<AddBookingDto, Booking>();
            CreateMap<UpdateBookingDto, Booking>();

            //Payment
            CreateMap<Payment, GetPaymentDto>();
            CreateMap<AddPaymentDto, Payment>();
            CreateMap<updatePaymentDto,Payment>();
        }
    }
}
