using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentistBooking.Data.DataContext;
using DentistBooking.Data.Entities;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Dentists;
using DentistBooking.ViewModels.System.Services;
using DentistBooking.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace DentistBooking.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly DentistDBContext _context;
        private readonly UserManager<User> _userService;
        private readonly RoleManager<Role> _roleManager;


        public UserService(DentistDBContext context, UserManager<User> userService, RoleManager<Role> roleManager)
        {
            _context = context;
            _userService = userService;
            _roleManager = roleManager;
        }

        public async Task<ListUserResponse> GetUserList(PaginationFilter filter)
        {
            ListUserResponse response = new();
            PaginationDTO paginationDto = new();

            var orderBy = filter._order.ToString();

            orderBy = orderBy switch
            {
                "1" => "descending",
                "-1" => "ascending",
                _ => orderBy
            };


            var usersInUserRole = await (from user in _context.Users
                    join userRole in _context.UserRoles
                        on user.Id equals userRole.UserId
                    join role in _context.Roles
                        on userRole.RoleId equals role.Id
                    where role.Name.Equals("User")
                    select user
                )
                .OrderBy(filter._by + " " + orderBy)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();


            List<UserDTO> userDtoList = new();


            var totalRecords = (from user in _context.Users
                    join userRole in _context.UserRoles
                        on user.Id equals userRole.UserId
                    join role in _context.Roles
                        on userRole.RoleId equals role.Id
                    where role.Name.Equals("User") && user.Status != Status.INACTIVE
                    select user
                ).Count();

            if (!usersInUserRole.Any())
            {
                response.Content = null;
                response.Code = "200";
                response.Message = "There aren't any users in DB";
            }
            else
            {
                foreach (var item in usersInUserRole)
                {
                    userDtoList.Add(MapToDto(item));
                }

                response.Content = userDtoList;
                response.Message = "SUCCESS";
                response.Code = "200";
            }

            var totalPages = ((double)totalRecords / (double)filter.PageSize);
            var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            paginationDto.CurrentPage = filter.PageNumber;
            paginationDto.PageSize = filter.PageSize;
            paginationDto.TotalPages = roundedTotalPages;
            paginationDto.TotalRecords = totalRecords;

            response.Pagination = paginationDto;


            return response;
        }

        public async Task<DentistCodeResponse> UpdateUser(UpdateUserRequest request)
        {
            var response = new DentistCodeResponse();

            var user = _context.Users.FirstOrDefault(x => x.Id == request.UserId);


            if (user != null)
            {
                user.DOB = (DateTime)request.DOB;
                user.Email = request.Email;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.PhoneNumber = request.PhoneNumber;
                user.Gender = (Gender)request.Gender;
            }

            await _userService.UpdateAsync(user);


            await _context.SaveChangesAsync();
            response.Code = "200";
            response.Message = "Updated successfully";

            return response;
        }

        public async Task<DentistCodeResponse> DeleteUser(Guid userId)
        {
            var response = new DentistCodeResponse();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                response.Code = "404";
                response.Message = "Error";
                return response;
            }

            if (user.Status == Status.INACTIVE)
            {
                user.Deleted_at = null;
                user.Status = Status.ACTIVE;
            }
            else
            {
                user.Deleted_at = DateTime.Parse(DateTime.Now.ToString("yyyy/MMM/dd"));
                user.Status = Status.INACTIVE;
            }

            var rs = await _context.SaveChangesAsync();
            response.Code = "200";
            response.Message = "Delete successfully";


            return response;
        }

        public async Task<UserDTO> GetUser(Guid userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                return MapToDto(user);
            }
            catch (DbUpdateException e)
            {
                return null;
            }
        }

        private UserDTO MapToDto(User user)
        {
            UserDTO dto = new();
            dto.Email = user.Email;
            dto.Gender = user.Gender;
            dto.Id = user.Id.ToString();
            dto.Phone = user.PhoneNumber;
            dto.DOB = user.DOB;
            dto.Status = user.Status;
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;

            return dto;
        }

        private string GetRoleFromUser(User user)
        {
            var roles = _userService.GetRolesAsync(user).Result;
            var roleName = roles.First();

            return roleName;
        }
    }
}