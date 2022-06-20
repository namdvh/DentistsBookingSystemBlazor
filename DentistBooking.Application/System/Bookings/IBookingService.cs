using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.Application.System.Bookings
{
    public interface IBookingService
    {
        Task<BookingResponse> CreateBooking(CreateBookingRequest request);
        Task<ListBookingResponse> GetBookingList(PaginationFilter filter);
        Task<ListBookingResponse> GetBookingListForUser(PaginationFilter filter,Guid userId);
        Task<BookingResponse> UpdateBooking(BookingRequest request);
        Task<BookingResponse> UpdateBookingStatus(BookingStatusRequest request);
        Task<BookingResponse> DeleteBooking(string bookingId, Guid userId);
        Task<BookingDetailResponse> GetBookingDetail(int bookingId);
        
        Task<ListBookingDTOResponse> GetBookingListForDentist(PaginationFilter filter, int dentistId);

        Task<List<KeyTime>> GetPostListKeyTime(int clinicId, int serviceId, DateTime date);


    }
}
