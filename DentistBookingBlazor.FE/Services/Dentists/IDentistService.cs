using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Dentists;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Dentists
{
    public interface IDentistService
    {
        Task<DentistResponse> GetDentistList(PaginationFilter filter);

    }
}
