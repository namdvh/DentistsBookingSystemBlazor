
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Discounts;
using DentistBooking.ViewModels.System.Services;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Discounts;
using DentistBookingBlazor.FE.Services.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.AdminPage
{
    public partial class Service
    {
        [Inject]
        private IServiceService ServiceService { get; set; }
        [Inject]
        private IDiscountService DiscountService { get; set; }

        protected Confirmation DeleteConfirmation { get; set; }

        private int DeleteId { get; set; }

        private List<ServiceDto> service;
        private List<DiscountDTO> discount;
        private ListServiceResponse response;
        private ListDiscountResponse discountResponse;
        private PaginationDTO paginationDTO;

        PaginationFilter paginationFilter = new();


        protected override async Task OnInitializedAsync()
        {
            await GetServices();
            await GetDiscounts();

        }

        private async Task GetServices()
        {
            response = await ServiceService.GetServiceList(paginationFilter);
            service = (List<ServiceDto>)response.Content;
            paginationDTO = response.Pagination;
        }

        private async Task GetDiscounts()
        {
            discountResponse = await DiscountService.GetDiscountList(paginationFilter);
            discount = (List<DiscountDTO>)discountResponse.Content;
        }



        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetServices();
            await GetDiscounts();

        }

        public async Task OnDeleteService(int deleteId, int checkStatus)
        {
            if (checkStatus != -1)
            {
                DeleteId = deleteId;
                DeleteConfirmation.Show();
            }
            else
            {
                await ServiceService.DeleteService(deleteId);
                await GetServices();
                await GetDiscounts();

            }

        }

        public async Task OnConfirmDeleteService(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await ServiceService.DeleteService(DeleteId);
                await GetServices();
                await GetDiscounts();

            }
        }

    }
}
