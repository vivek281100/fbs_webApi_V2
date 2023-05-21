using fbs_webApi_v2.Data;
using fbs_webApi_v2.DTOs.BookingDtos;

namespace fbs_webApi_v2.services.IRepositories
{
    public interface IBookingRepository
    {
        public  Task<serviceResponce<List<GetBookingDto>>> GetBookingsbyuserId();
        public Task<serviceResponce<GetBookingDto>> AddBookingAsync(AddBookingDto addBooking);

        public Task<serviceResponce<string>> DeleteBooking(int id);
    }
}
