using Blazored.Toast.Services;
using DentistBooking.Blazor.Services.Users;
using DentistBooking.ViewModels.System.Users;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class Register
    {
        private RegisterRequest registerRequest = new RegisterRequest();
        [Inject] private IUserService userService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IToastService toast { get; set; }
        public bool ShowRegistrationErrors { get; set; }
        public IEnumerable<string> Message { get; set; }

        public async Task Registers()
        {
            ShowRegistrationErrors = false;
            var result = await userService.Register(registerRequest);
            if (!result.Successfull)
            {
                ShowRegistrationErrors = true;
                Message = result.Messages;
                toast.ShowError($"An error occurred in progress. Please contact to administrator.", "Error");
            }
            else
            {
                toast.ShowSuccess($"{registerRequest.UserName} has been created Successflly.", "Success");
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
