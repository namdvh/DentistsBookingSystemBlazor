using Blazored.LocalStorage;
using DentistBooking.Blazor.Services.Users;
using DentistBookingBlazor.FE.Services.Clinics;
using DentistBookingBlazor.FE.Services.Dentists;
using DentistBookingBlazor.FE.Services.Discounts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddTransient<IClinicService, ClinicService>();
            builder.Services.AddTransient<IDentistService, DentistService>();
            builder.Services.AddTransient<IDiscountService, DiscountService>();
            //builder.Services.AddTransient<IValidator<ClinicRequest>, ClinicRequestValidator>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });




            await builder.Build().RunAsync();
        }
    }
}
