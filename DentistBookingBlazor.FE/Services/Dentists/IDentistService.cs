using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using DentistBooking.ViewModels.System.Dentists;
using System;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Dentists
{
    public interface IDentistService
    {
        Task<DentistResponse> GetDentistList(PaginationFilter filter);

        Task<bool> CreateDentist(AddDentistRequest request);
        Task<DentistDTO> GetDentist(Guid userID);

        Task<ListClinicResponse> GetClinic();

    }
}
