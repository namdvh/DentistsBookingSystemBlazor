using DentistBooking.Data.Entities;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Discounts;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Discounts
{
    public interface IDiscountService
    {
        Task<ListDiscountResponse> GetDiscountList(PaginationFilter filter);
        Task<bool> CreateDiscount(DiscountRequest request);
        Task<bool> UpdateDiscount(DiscountRequest request);
        Task<bool> DeleteDiscount(int discountId);
        Task<DiscountDTO> GetDiscount(int discountId);
        Task<bool> ApplyForAll(int discountId);
    }
}
