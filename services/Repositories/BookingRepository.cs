using AutoMapper;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.BookingDtos;
using fbs_webApi_v2.DTOs.passengerDtos;
using fbs_webApi_v2.services.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace fbs_webApi_v2.services.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly fbscontext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingRepository(fbscontext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        //getting user id
        //user 
        #region Get user id
        private int GetUserId()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
        #endregion


        #region(get bookings by userid)

        public async Task<serviceResponce<List<GetBookingDto>>> GetBookingsbyuserId()
        {
            var responce = new serviceResponce<List<GetBookingDto>>();

            try
            {
                var bookings = await _context.Bookings.Where(b => b.UserId == GetUserId()).ToListAsync();

                if (bookings.Any())
                {
                    responce.Data = _mapper.Map<List<GetBookingDto>>(bookings);
                    responce.Success = true;
                    responce.Message = "Bookings Retrived";
                }
                else
                {
                    responce.Success = false;
                    responce.Message = "When you make booking it will apper Here";
                }

                return responce;
            }
            catch (Exception ex)
            {
                responce.Success=false;
                responce.Message = ex.Message;  
            }

            return responce;
        }
        #endregion


        //add booking
        //user and admin access
        #region (Add Booking)
        public async Task<serviceResponce<GetBookingDto>> AddBookingAsync(AddBookingDto addBooking)
        {
            var BookingAdd = await _context.Bookings.FirstOrDefaultAsync(b => b.UserId == GetUserId());
            var responce = new serviceResponce<GetBookingDto>();

           var booking = _mapper.Map<Booking>(addBooking);

            booking.User = await _context.users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            
            booking.bookingdatetime = DateTime.Now;


            try
            {
                _context.Bookings.Add(booking);

                await _context.SaveChangesAsync();

                var latestbooking =  _context.Bookings.OrderByDescending(b => b.Id).FirstOrDefault()?.Id ?? 0;

                responce.Data = await _context.Bookings
                    .Where(b => b.Id == latestbooking)
                .Select(p => _mapper.Map<GetBookingDto>(p)).FirstOrDefaultAsync();

                //.Where(p => p.User.Id == GetUserId())
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.Success = false;
            }

            return responce;
        }
        #endregion


        //Delete booking by id
        //user and admin access
        #region(delete booking)

        public async Task<serviceResponce<string>> DeleteBooking(int id)
        {
            var responce = new serviceResponce<string>();

            try
            {
                var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
                if (booking != null)
                {
                    _context.Bookings.Remove(booking);
                    await _context.SaveChangesAsync();

                    responce.Data = "booking removed";
                    responce.Success = true;
                    responce.Message = "successful";
                }
                else
                {
                    responce.Success = false;
                    responce.Data = "booking not fount";
                    responce.Message = "failed";

                }
                return responce;
            }
            catch(Exception ex)
            {
                responce.Message = ex.Message;
                return responce;
            }
        }
        #endregion
    }
}
