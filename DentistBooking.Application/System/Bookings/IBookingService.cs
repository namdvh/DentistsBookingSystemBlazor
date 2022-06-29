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
        BookingResponse CreateBooking(CreateBookingRequest request);
        Task<ListBookingResponse> GetBookingList(PaginationFilter filter);
        Task<ListBookingResponse> GetBookingListForUser(PaginationFilter filter,Guid userId);
        Task<BookingResponse> UpdateBooking(BookingRequest request);
        Task<BookingResponse> UpdateBookingStatus(BookingStatusRequest request);
        Task<BookingResponse> UpdateBookingDetailStatus(BookingDetailStatusRequest request);
        Task<BookingResponse> DeleteBooking(string bookingId, Guid userId);
        Task<BookingResponse> DeleteBookingByUser(int bookingId);
        Task<BookingDetailResponse> GetBookingDetail(int bookingId);
        
        Task<ListBookingDTOResponse> GetBookingListForDentist(PaginationFilter filter, int dentistId);

        List<KeyTime> GetPostListKeyTime(int clinicId, int serviceId, DateTime date);
        Task<BookingDetailResponse> GetDetailByDentistAndBooking(int dentistId, int bookingId);


    }
}
