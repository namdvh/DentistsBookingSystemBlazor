using DentistBooking.Data.DataContext;
using DentistBookingBlazor.FE.Services.Files;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.Files
{
    public partial class FileUpload
    {
        [Inject]
        private IFileApiClient fileApiClient { get; set; }
        private FileDto fileDto;
        private DentistDBContext _context;
        protected async override Task OnInitializedAsync()
        {
            await GetFiles();

        }

        private async Task GetFiles()
        {
            fileDto = await fileApiClient.GetFile();
            if (fileDto != null)
            {
                var file = Path.GetFileNameWithoutExtension(fileDto.Image.FileName);
                var extensions = Path.GetExtension(fileDto.Image.FileName);
                var result = file + extensions;
            }
            
        }
    }
}
