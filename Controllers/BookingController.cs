using Azure;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DTOs.BookingDtos;
using fbs_webApi_v2.services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fbs_webApi_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        [Route("GetBookingsbyUser")]
        public async Task<ActionResult<serviceResponce<List<GetBookingDto>>>> getbookingsByuser()
        {
            try
            {
                var responce = await _bookingRepository.GetBookingsbyuserId();

                return Ok(responce);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("AddBookingasync")]
       public async Task<ActionResult<serviceResponce<GetBookingDto>>> AddBooking([FromBody]int flightid)

        {
            try
            {
                var addBooking = new AddBookingDto();
                addBooking.FlightId = flightid;
                var responce = await _bookingRepository.AddBookingAsync(addBooking);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpPost]
        [Route("DeleteBooking")]
        public async Task<ActionResult<serviceResponce<string>>> deleteBooking([FromBody]int id)
        {
            try
            {
                var responce = await _bookingRepository.DeleteBooking(id);
                return Ok(responce);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }
    }
}
