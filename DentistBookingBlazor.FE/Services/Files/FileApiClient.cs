using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Files
{
    public class FileApiClient : IFileApiClient
    {
        private readonly HttpClient _httpClient;
        public FileApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<FileDto> GetFile()
        {
            var rs = await _httpClient.GetFromJsonAsync<FileDto>($"/api/FileUpload/file/upload");
            return rs;
        }
    }
}
