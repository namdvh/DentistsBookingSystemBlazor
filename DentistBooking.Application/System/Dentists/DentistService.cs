﻿using DentistBooking.Data.DataContext;
using DentistBooking.Data.Entities;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Dentists;
using DentistBooking.ViewModels.System.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace DentistBooking.Application.System.Dentists
{
    public class DentistService : IDentistService
    {
        private readonly DentistDBContext _context;
        private readonly UserManager<User> _userService;
        private readonly RoleManager<Role> _roleManager;
        private const string DENTIST_ID = "20efd516-f16c-41b3-b11d-bc908cd2056d";

        public DentistService(DentistDBContext context, UserManager<User> userService, RoleManager<Role> roleManager)
        {
            _context = context;
            _userService = userService;
            _roleManager = roleManager;

        }

        public async Task<DentistResponse> GetDentistList(PaginationFilter filter)
        {
            DentistResponse response = new();
            PaginationDTO paginationDto = new();

            var orderBy = filter._order.ToString();

            orderBy = orderBy switch
            {
                "1" => "descending",
                "-1" => "ascending",
                _ => orderBy
            };

            var data = (dynamic)null;

            if (true)
            {
                data = await (from user in _context.Users
                              join dentist in _context.Dentists on user.DentistId equals dentist.Id into dentistsUser
                              from dentistAttribute in dentistsUser.DefaultIfEmpty()
                              select new { user, dentistAttribute })
                    .Where(x => x.user.DentistId != null)
                    .OrderByDescending(x => x.user.Created_at)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
            }


            List<DentistDTO> dentistList = new();


            var totalRecords = await _context.Dentists.CountAsync(x => x.User.DentistId != null);

            if (data == null)
            {
                response.Content = null;
                response.Code = "200";
                response.Message = "There aren't any dentists in DB";
            }
            else
            {
                foreach (var item in data)
                {
                    List<ServiceDto> services = new();

                    ServiceDto serviceDto = new();

                    DentistDTO dto = new();
                    dto.Description = item.dentistAttribute?.Description;
                    dto.Email = item.user.Email;
                    dto.Gender = item.user.Gender;
                    dto.Id = item.user.Id;
                    dto.Phone = item.user.PhoneNumber;
                    dto.UserName = item.user.UserName;
                    dto.Position = item.dentistAttribute.Position;
                    dto.Dob = item.user.DOB;
                    dto.Status = item.user.Status;
                    dto.FirstName = item.user.FirstName;
                    dto.LastName = item.user.LastName;
                    dto.DentistID = item.dentistAttribute.Id;
                    dto.ClinicID = item.dentistAttribute.ClinicId;

                    dto.Services = await GetServiceFromDentist(item.dentistAttribute.Id);

                    dentistList.Add(dto);
                }

                response.Content = dentistList;
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

        public async Task<DentistResponse> CreateDentist(AddDentistRequest request)
        {
            var response = new DentistResponse();
            var validator = new AddDentistRequestValidator();
            response.Errors = new List<string>();
            var results = await validator.ValidateAsync(request);
            var defaultRole = _roleManager.FindByIdAsync(DENTIST_ID).Result;


            var clinic = _context.Clinics.FirstOrDefault(x => x.Id == request.ClinicId);


            if (!results.IsValid)
            {
                response.Content = null;
                response.Code = "200";
                foreach (var failure in results.Errors)
                {
                    response.Errors.Add(failure.ErrorMessage.ToString());
                }

                return response;
            }

            var newDentist = new Dentist()
            {
                Clinic = clinic,
                Description = request.Description,
                Position = request.Position,
            };

            var rs = _context.Dentists.Add(newDentist);
            await _context.SaveChangesAsync();

            var newUser = new User()
            {
                DOB = request.DOB,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Status = Status.ACTIVE,
                Gender = request.Gender,
                Dentist = newDentist
            };

            var result = await _userService.CreateAsync(newUser, request.Password);

            if (result.Succeeded)
            {
                var dentistService = new ServiceDentist();
                await _userService.AddToRoleAsync(newUser, defaultRole.Name);

                if (request.ServiceId != null && request.ServiceId.Any())
                {
                    foreach (var x in request.ServiceId)
                    {
                        dentistService.DentistId = newDentist.Id;
                        dentistService.ServiceId = x;

                        _context.ServiceDentists.Add(dentistService);
                        await _context.SaveChangesAsync();
                    }
                }

                response.Code = "200";
                response.Message = "Register successfully";

                return response;
            }

            response.Content = null;
            response.Code = "200";
            response.Message = "Register failed";

            return response;
        }

        public async Task<DentistCodeResponse> UpdateDentist(UpdateDentistRequest request)
        {
            var response = new DentistCodeResponse();
            var dentist = _context.Dentists.FirstOrDefault(x => x.Id == request.Id);
            var clinic = _context.Clinics.FirstOrDefault(x => x.Id == request.ClinicId);
            var dentistService = new ServiceDentist();
            bool flag = false;

            var postService = _context.ServiceDentists.Where(x => x.DentistId == dentist.Id).Select(x => x.ServiceId).ToList();

            if (dentist != null)
            {
                if (clinic != null) dentist.Clinic = clinic;
                dentist.Description = request.Description;
                if (request.Position != null) dentist.Position = (Position)request.Position;

                var services = _context.Services.ToList();



                //foreach (var x in request.ServiceId)
                //{
                //    if (_context.ServiceDentists.Any(y => y.DentistId == dentist.Id && y.ServiceId == x))
                //    {
                //    }
                //    else
                //    {
                //        dentistService.DentistId = dentist.Id;
                //        dentistService.ServiceId = x;

                //        _context.ServiceDentists.Add(dentistService);
                //        await _context.SaveChangesAsync();
                //    }

                //}
                foreach (var option in services)
                {
                    if (request.ServiceId.Contains(option.Id))       //is checked
                    {
                        if (!postService.Contains(option.Id))
                        {
                            dentistService = new();
                            dentistService.DentistId = dentist.Id;
                            dentistService.ServiceId = option.Id;
                            _context.ServiceDentists.Add(dentistService);
                            await _context.SaveChangesAsync();

                        }
                    }
                    else
                    {
                        if (postService.Contains(option.Id))
                        {
                            dentistService = new();
                            dentistService.DentistId = dentist.Id;
                            dentistService.ServiceId = option.Id;
                            _context.ServiceDentists.Remove(dentistService);
                            await _context.SaveChangesAsync();
                        }
                    }



                }

                var user = _context.Users.FirstOrDefault(x => x.DentistId == dentist.Id);
                if (user != null)
                {
                    if (request.Dob != null) user.DOB = (DateTime)request.Dob;
                    user.Email = request.Email;
                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                    user.UserName = request.UserName;
                    user.PhoneNumber = request.PhoneNumber;
                    if (request.Status != null) user.Status = (Status)request.Status;
                    if (request.Gender != null) user.Gender = (Gender)request.Gender;
                    user.Updated_by = request.UpdatedBy;
                }

                await _userService.UpdateAsync(user);
            }


            await _context.SaveChangesAsync();
            response.Code = "200";
            response.Message = "Updated successfully";

            return response;
        }

        public async Task<DentistCodeResponse> DeleteDentist(int dentistID)
        {
            var response = new DentistCodeResponse();
            var user = _context.Users.FirstOrDefault(x => x.DentistId == dentistID);

            if (user == null)
            {
                response.Code = "404";
                response.Message = "Error";
                return response;
            }
            else
            {
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
            }

            await _userService.UpdateAsync(user);
            response.Code = "200";
            response.Message = "Delete successfully";


            return response;
        }


        private async Task<List<ServiceDto>> GetServiceFromDentist(int dentistId)
        {
            var results = await (from t1 in _context.ServiceDentists
                                 join t2 in _context.Services
                                     on t1.ServiceId equals t2.Id
                                 where t1.DentistId == dentistId
                                 select t2).ToListAsync();

            var final = new List<ServiceDto>();

            foreach (var service in results)
            {
                ServiceDto dto = new();
                dto.Id = service.Id;
                dto.ServiceName = service.Name;
                final.Add(dto);
            }

            return final;
        }

        public async Task<DentistDTO> GetDentist(Guid userID)
        {
            try
            {
                var data = await (from user in _context.Users
                                  join dentist in _context.Dentists on user.DentistId equals dentist.Id into dentistsUser
                                  from dentistAttribute in dentistsUser.DefaultIfEmpty()
                                  where user.Deleted_by == null && user.Id == userID
                                  select new { user, dentistAttribute })
                    .Where(x => x.user.DentistId != null).FirstOrDefaultAsync();


                DentistDTO dto = new();
                dto.Description = data.dentistAttribute?.Description is null ? "":data.dentistAttribute?.Description;
                dto.Email = data.user.Email;
                dto.Gender = data.user.Gender;
                dto.Id = data.user.Id;
                dto.Phone = data.user.PhoneNumber;
                dto.UserName = data.user.UserName;
                dto.Position = data.dentistAttribute.Position;
                dto.Dob = data.user.DOB;
                dto.Status = data.user.Status;
                dto.FirstName = data.user.FirstName;
                dto.LastName = data.user.LastName;
                dto.DentistID = data.dentistAttribute.Id;
                dto.ClinicID = data.dentistAttribute.ClinicId;

                dto.Services = await GetServiceFromDentist(data.dentistAttribute.Id);


                return dto;

            }
            catch (DbUpdateException)
            {

                return null;
            }
        }
    }
}