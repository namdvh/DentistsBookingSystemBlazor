
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Discounts;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Discounts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.AdminPage
{
    public partial class Discount
    {
        [Inject]
        private IDiscountService DiscountService { get; set; }

        protected Confirmation DeleteConfirmation { get; set; }

        private int DeleteId { get; set; }

        private List<DiscountDTO> discount;
        private ListDiscountResponse response;
        private PaginationDTO paginationDTO;

        PaginationFilter paginationFilter = new();

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/Error");
            }
            await GetDiscounts();
        }

        private async Task GetDiscounts()
        {
            response = await DiscountService.GetDiscountList(paginationFilter);
            discount = (List<DiscountDTO>)response.Content;
            paginationDTO = response.Pagination;
        }



        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetDiscounts();
        }

        public async Task OnDeleteDiscount(int deleteId, int checkStatus)
        {
            if (checkStatus != -1)
            {
                DeleteId = deleteId;
                DeleteConfirmation.Show();
            }
            else
            {
                await DiscountService.DeleteDiscount(deleteId);
                await GetDiscounts();
            }

        }

        public async Task OnApply(int discountId)
        {
            await DiscountService.ApplyForAll(discountId);
            await GetDiscounts();
        }

        public async Task OnConfirmDeleteDiscount(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await DiscountService.DeleteDiscount(DeleteId);
                await GetDiscounts();
            }
        }
    }
}
