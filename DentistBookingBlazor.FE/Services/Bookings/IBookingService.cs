using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Bookings
{
    public interface IBookingService
    {
        Task<List<KeyTime>> GetPostListKeyTime(int clinicId, int serviceId, DateTime date);
        Task<bool> CreateBooking(CreateBookingRequest request);
        Task<ListBookingResponse> GetBookingList(PaginationFilter filter);
        Task<bool> UpdateBooking(BookingRequest request);
        Task<bool> UpdateBookingStatus(BookingStatusRequest request);
        Task<BookingDetailResponse> GetBookingDetail(int bookingId);
        Task<ListBookingDTOResponse> GetBookingListForDentist(PaginationFilter filter,int dentistId);
        Task<ListBookingDTOResponse> GetBookingListForUser(PaginationFilter filter,Guid userId);
        Task<BookingDetailResponse> GetDetailByDentistAndBooking(int dentistId, int bookingId);
        Task<bool> DeleteBookingByUser(int bookingId);






    }
}
