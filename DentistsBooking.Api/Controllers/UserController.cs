﻿using DentistBooking.Application.System.Users;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DentistsBooking.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter._by, filter._order);
            var result = await _userService.GetUserList(validFilter);
            return Ok(result);
        }

        [HttpGet]
        [Route("{userID}")]
        public async Task<IActionResult> GetDentist([FromRoute] Guid userID)
        {
            UserDTO result = await _userService.GetUser(userID);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDentist([FromBody] UpdateUserRequest request)
        {
            var result = await _userService.UpdateUser(request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> RemoveDentist([FromRoute] Guid userId)
        {
            var result = await _userService.DeleteUser(userId);
            return Ok(result);
        }  
    }
}