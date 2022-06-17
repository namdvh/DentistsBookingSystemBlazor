using Blazored.LocalStorage;
using DentistBooking.Blazor.Services.Users;
using DentistBookingBlazor.FE.Services.Clinics;
using DentistBookingBlazor.FE.Services.Discounts;
using DentistBookingBlazor.FE.Services.Dentists;
using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using DentistBookingBlazor.FE.Services.Services;
using DentistBookingBlazor.FE.Services.Bookings;

namespace DentistBookingBlazor.FE
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddTransient<IClinicService, ClinicService>();
            builder.Services.AddTransient<IDentistService, DentistService>();
            builder.Services.AddTransient<IDiscountService, DiscountService>();
            builder.Services.AddTransient<IServiceService, ServiceService>();
            builder.Services.AddTransient<IBookingService, BookingService>();
            //builder.Services.AddTransient<IValidator<ClinicRequest>, ClinicRequestValidator>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });




            await builder.Build().RunAsync();
        }
    }
}
