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


        //getbookings by userid
        #region get booking by user id

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

        #endregion


        //get bookings by flight if
        #region get flights by flight id
        [HttpGet]
        [Route("getbookingsbyflightId")]
        public async Task<IActionResult> getbookingbyflightid(int id)
        {
            try
            {
                var bookings = await _bookingRepository.getBookingbyflightId(id);
                return Ok(bookings);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        //add booking
        #region add booking
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
        #endregion


        //delete id
        #region delete booking

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

        #endregion
    }
}
