using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Services;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Services
{
    public interface IServiceService
    {
        Task<ListServiceResponse> GetServiceList(PaginationFilter filter);
        Task<bool> CreateService(AddServiceRequest request);
        Task<bool> UpdateService(ServiceRequest request);
        Task<bool> DeleteService(int serviceId);
        Task<ServiceDto> GetService(int serviceId);
        Task<ListServiceResponse> GetServiceListByClinic(int clinicId);

    }
}
