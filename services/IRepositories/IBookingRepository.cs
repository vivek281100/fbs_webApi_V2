using fbs_webApi_v2.Data;
using fbs_webApi_v2.DTOs.BookingDtos;

namespace fbs_webApi_v2.services.IRepositories
{
    public interface IBookingRepository
    {
         Task<serviceResponce<List<GetBookingDto>>> GetBookingsbyuserId();

        Task<serviceResponce<List<GetBookingDto>>> getBookingbyflightId(int id);
         Task<serviceResponce<GetBookingDto>> AddBookingAsync(AddBookingDto addBooking);

         Task<serviceResponce<string>> DeleteBooking(int id);
    }
}
