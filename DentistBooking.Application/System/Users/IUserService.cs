﻿using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Dentists;
using DentistBooking.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace DentistBooking.Application.System.Users
{
    public interface IUserService
    {
        Task<ListUserResponse> GetUserList(PaginationFilter filter);
        Task<DentistCodeResponse> UpdateUser(UpdateUserRequest request);
        Task<DentistCodeResponse> DeleteUser(Guid userId);
        Task<UserDTO> GetUser(Guid userId);
    }
}