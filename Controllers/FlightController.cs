using fbs_webApi_v2.Data;
using fbs_webApi_v2.DTOs.FlightDtos;
using fbs_webApi_v2.services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbs_webApi_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;

        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        [HttpGet]
        [Route("getFlights")]
        public async Task<ActionResult<serviceResponce<List<GetFlightDto>>>> getflights()
        {
            var flights = await _flightRepository.GetAllFlightsAsync();
            if(flights.Success)
            {
                return Ok(flights);
            }

            return BadRequest(flights);

        }

        [HttpGet]
        [Route("getflightsbyid/{id}")]
        public async Task<ActionResult<serviceResponce<GetFlightDto>>> getflightbyid(int id)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            if(flight.Success)
            {
                return Ok(flight);
            }
            return BadRequest(flight);
        }



        [HttpPost]
        [Route("AddFlight")]
        public async Task<ActionResult<serviceResponce<List<GetFlightDto>>>> addflight(AddFlightDto addflight)
        {
            var responce = await _flightRepository.AddFlightAsync(addflight);
            if(responce.Success)
            {
                return Ok(responce);
            }
            return BadRequest(responce);
        }

        [HttpPost]
        [Route("getflightsbyfromandto")]
        public async Task<ActionResult<serviceResponce<List<GetFlightDto>>>> searchflights(SearchFlightDto searchflights)
        {
            var responce = await _flightRepository.SearchFlights(searchflights);
            if(responce.Success)
            {
                return Ok(responce);
            }
            return BadRequest(responce);
        }

        [HttpPut]
        [Route("UpdateFlights")]
        public async Task<ActionResult<serviceResponce<GetFlightDto>>> updateFlight(UpdateFlightDto updateflight)
        {
            var responce = await _flightRepository.UpdateFlightAsync(updateflight);
            if(responce.Success)
            {
                return Ok(responce);
            }
            return BadRequest(responce);
        }

        [HttpDelete]
        [Route("deleteFlight")]
        public async Task<ActionResult<serviceResponce<GetFlightDto>>> deleteflight(int id)
        {
            var responce = await _flightRepository.DeleteFlightByIdAsync(id);
            if(responce.Success)
            {
                return Ok(responce);
            }    

            return BadRequest(responce);
        }
    }
}
