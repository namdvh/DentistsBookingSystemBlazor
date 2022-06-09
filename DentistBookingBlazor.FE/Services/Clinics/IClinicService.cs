
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Clinics
{
    public interface IClinicService
    {
        Task<ListClinicResponse> GetClinicList(PaginationFilter filter);
        Task<bool> CreateClinic(ClinicRequest request);
        Task<bool> UpdateClinic(ClinicRequest request);
        Task<bool> DeleteClinic(int clinicId);
        Task<ClinicDTO> GetClinic(int clinicId);
    }
}
