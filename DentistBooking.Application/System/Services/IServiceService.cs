using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.Application.System.Services
{
    public interface IServiceService
    {
        Task<ListServiceResponse> GetServiceList(PaginationFilter filter);
        Task<ServiceResponse> CreateService(AddServiceRequest request);
        Task<ServiceResponse> UpdateService(ServiceRequest request);
        Task<ServiceResponse> DeleteService(int clinicId, Guid userId);
    }
}
