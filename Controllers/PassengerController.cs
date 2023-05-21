﻿using fbs_webApi_v2.services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DTOs.passengerDtos;
using System.Security.Claims;

namespace fbs_webApi_v2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;
        //private readonly IMapper _mapper;
        public PassengerController(IPassengerRepository passengerRepository, IMapper mapper)
        {
            _passengerRepository = passengerRepository;
            //_mapper = mapper;
        }

        [HttpGet]
        [Route("GetPassengers")]
        public async Task<ActionResult<serviceResponce<List<GetPassengerDto>>>> GetAllPassengers()
        {
            //int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var responce = _passengerRepository.GetAllPassengersAsync();
            if (responce.Result.Success)
            {
                return Ok(responce.Result);
            }
            return BadRequest(responce.Result);
        }

        [HttpGet]
        [Route("GetPassengersbyuserid/")]
        public async Task<ActionResult<serviceResponce<List<GetPassengerDto>>>> getPassengersbyuserid()
        {
            //int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var responce = _passengerRepository.GetPassengersByuserIdAsync();
            if (responce.Result.Success)
            {
                return Ok(responce.Result);
            }

            return BadRequest(responce.Result);
        }

        [HttpPost]
        [Route("AddPassenger")]
        public async Task<ActionResult<serviceResponce<List<GetPassengerDto>>>> AddPassengerForUser(AddPassengerDto addpassenger)
        {
            //int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var responce = await _passengerRepository.AddPassengerAsync(addpassenger);

            if (responce.Success)
            {
                return Ok(responce);
            }

            return BadRequest(responce);
        }


        [HttpPut]
        [Route("updatePassenger")]
        public async Task<ActionResult<serviceResponce<GetPassengerDto>>> updatePassenger(UpdatePassengerDto updatepassenger)
        {
            var responce = await _passengerRepository.UpdatePassengerAsync(updatepassenger);

            if (responce.Success)
            {
                return Ok(responce);
            }

            return BadRequest(responce);
        }


        [HttpPost]
        [Route("RemovePassenger")]
        public async Task<ActionResult<serviceResponce<GetPassengerDto>>> deletePassenger(int id)
        {
            try
            {
                var responce = await _passengerRepository.DeletePassangerAsync(id);

                
                    return Ok(responce);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }

    }

}
