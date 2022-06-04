using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Dentists;
using DentistBookingBlazor.FE.Services.Dentists;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class Dentist
    {
        [Inject]
        private IDentistService DentistService { get; set; }

        private List<DentistDTO> dentist;
        private DentistResponse response;
        private PaginationDTO paginationDTO;
        PaginationFilter paginationFilter = new();


        protected override async Task OnInitializedAsync()
        {
            await GetDentists();
        }

        private async Task GetDentists()
        {
            response = await DentistService.GetDentistList(paginationFilter);
            dentist = (List<DentistDTO>)response.Content;
            paginationDTO = response.Pagination;
        }



        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetDentists();
        }
    }
}
