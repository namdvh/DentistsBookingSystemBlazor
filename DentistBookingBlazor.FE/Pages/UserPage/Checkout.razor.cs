﻿using Blazored.LocalStorage;
using Blazored.SessionStorage;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.System.Bookings;
using DentistBookingBlazor.FE.Services.Bookings;
using DentistBookingBlazor.FE.Services.Discounts;
using DentistBookingBlazor.FE.Services.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.UserPage
{
    public partial class Checkout
    {
        public CreateBookingRequest request { get; set; }
        public List<CheckoutDTO> listCheckout = new();
        public string Note { get; set; }
        public decimal Total { get; set; }
        public decimal afterPrice { get; set; }
        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }
        [Inject]
        public ISessionStorageService sessionStorage { get; set; }
        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IServiceService ServiceService { get; set; }
        [Inject]
        public IDiscountService DiscountService { get; set; }
        [Inject]
        public IBookingService BookingService { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                NavManager.NavigateTo("/Error");
            }
            var savedToken = await ILocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(savedToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var role = tokenS.Claims.First(claim => claim.Type == "Role").Value;
            if (!role.Equals("User"))
            {
                NavManager.NavigateTo("/Error");
            }
            await GetCart();
        }

        private async Task GetCart()
        {
            request = await sessionStorage.GetItemAsync<CreateBookingRequest>("cart");
            if (request != null)
            {
                for (int i = 0; i < request.ServiceIds.Count; i++)
                {
                    var service = await ServiceService.GetService(request.ServiceIds[i]);
                    var discount = await DiscountService.GetDiscount(service.DiscountId);

                    CheckoutDTO checkoutDTO = new CheckoutDTO
                    {
                        ServiceNames = service.ServiceName,
                        KeyTimes = request.KeyTimes[i],
                        Price = service.Price - discount.Amount

                    };
                    Total += checkoutDTO.Price;
                    listCheckout.Add(checkoutDTO);
                }
            }
        }


        public async Task Buy()
        {
            request.Note = Note;
            request.Total = Total;
            var rs = await BookingService.CreateBooking(request);
            if (!rs)
            {
                ToastService.ShowError("Booking failed because all dentists are unavailabled, please try again!", "Error");
            }
            else
            {
                ToastService.ShowSuccess("Booking successfully.", "Success");
            }
            await sessionStorage.ClearAsync();
            NavManager.NavigateTo("/bookingCreate");
        }

        public async Task OnDeleteItem(KeyTime keytime)
        {
            for (int i = 0; i < request.KeyTimes.Count; i++)
            {
                if (request.KeyTimes[i] == keytime)
                {
                    request.KeyTimes.RemoveAt(i);
                    request.ServiceIds.RemoveAt(i);
                    listCheckout.RemoveAt(i);
                }
            }
            if (!request.KeyTimes.Any())
            {
                await sessionStorage.ClearAsync();
            }
            else
            {
                await sessionStorage.SetItemAsync("cart", request);
            }
            ToastService.ShowSuccess("Remove succesfully.", "Success");
        }
    }
}
