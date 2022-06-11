using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Files
{
    public interface IFileApiClient
    {
        Task<FileDto> GetFile();
    }
}
