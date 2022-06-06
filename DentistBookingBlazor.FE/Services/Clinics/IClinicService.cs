
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Clinics
{
    public interface IClinicService
    {
        Task<ListClinicResponse> GetClinicList(PaginationFilter filter);
    }
}
