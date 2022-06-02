using DentistBooking.ViewModels.System.Users;
using System.Threading.Tasks;

namespace DentistBooking.Blazor.Services.Users
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
    }
}
