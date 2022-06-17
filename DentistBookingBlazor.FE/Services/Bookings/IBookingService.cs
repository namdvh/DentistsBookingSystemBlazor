using DentistBooking.Data.Enum;
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


    }
}
