﻿
using Blazored.LocalStorage;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Discounts;
using DentistBooking.ViewModels.System.Services;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Discounts;
using DentistBookingBlazor.FE.Services.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }

        private List<ServiceDto> service;
        private List<DiscountDTO> discount;
        private ListServiceResponse response;
        private ListDiscountResponse discountResponse;
        private PaginationDTO paginationDTO;

        PaginationFilter paginationFilter = new();


        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/Error");
            }
            var savedToken = await ILocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(savedToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var role = tokenS.Claims.First(claim => claim.Type == "Role").Value;
            if (!role.Equals("Admin"))
            {
                NavigationManager.NavigateTo("/Error");
            }
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
                var rs = await ServiceService.DeleteService(DeleteId);

                if (rs)
                {
                    ToastService.ShowSuccess("Delete succesffuly", "Success");
                    NavigationManager.NavigateTo("/discount");
                }
                else
                {
                    ToastService.ShowError("Delete failed", "Failed");

                }
                await GetServices();
                await GetDiscounts();

            }
        }

    }
}
