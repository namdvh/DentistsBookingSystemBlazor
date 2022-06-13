using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace DentistBooking.Blazor.Services.Users
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<ListUserResponse> GetUserList(PaginationFilter filter);
        Task<bool> UpdateUser(UpdateUserRequest request);
        Task<bool> DeleteUser(Guid userId);
        Task<UserDTO> GetUser(Guid userId);
    }
}
