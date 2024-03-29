﻿using DentistBooking.Data.DataContext;
using DentistBooking.Data.Entities;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBooking.ViewModels.System.Dentists;
using DentistBooking.ViewModels.System.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace DentistBooking.Application.System.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly DentistDBContext _context;

        public BookingService(DentistDBContext context)
        {
            _context = context;
        }

        public BookingResponse CreateBooking(CreateBookingRequest request)
        {
            BookingResponse response = new BookingResponse();
            //bool flag = false;
            //List<KeyTime> postKeyTimes = new();

            try
            {
                //foreach (var item in request.ServiceIds)
                //{
                //    postKeyTimes =  GetPostListKeyTime(request.ClinicId, item, request.Date);
                //    if(postKeyTimes != null)
                //    {
                //        foreach (var kt in request.KeyTimes)
                //        {
                //            if (postKeyTimes.Contains(kt))
                //            {
                //                flag = true;
                //            }
                //        }
                //    }
                //}

                //if (!flag)
                //{


                Booking booking = new Booking()
                {
                    Status = Status.PENDING,
                    Date = request.Date,
                    Total = request.Total,
                    UserId = request.UserId,
                    Created_at = DateTime.Now
                };

                _context.Bookings.Add(booking);
                _context.SaveChanges();


                dynamic existedDetails = null;

                for (int i = 0; i < request.ServiceIds.Count; i++)
                {
                    var dentists = (from dentist in _context.Dentists
                                    join user in _context.Users
                                    on dentist.Id equals user.DentistId
                                    where dentist.ClinicId == request.ClinicId && user.Status != Status.INACTIVE
                                    select dentist).ToList();

                    existedDetails = (from t1 in _context.Bookings
                                      join t2 in _context.BookingDetails
                                      on t1.Id equals t2.BookingId
                                      where t1.Date.Equals(request.Date)
                                      && t2.KeyTime == request.KeyTimes[i]
                                      && t1.Status != Status.DECLINED
                                      select t2).ToList();

                    foreach (var item in existedDetails)
                    {
                        for (int j = 0; j < dentists.Count; j++)
                        {
                            if (item.DentistId == dentists[j].Id)
                            {
                                dentists.Remove(dentists[j]);
                            }
                        }

                    }

                    if (dentists.Count() == 0)
                    {
                        _context.Bookings.Remove(booking);
                        _context.SaveChanges(true);
                        return null;
                    }
                    else
                    {

                        BookingDetail detail = new BookingDetail()
                        {
                            BookingId = booking.Id,
                            DentistId = dentists[0].Id,
                            Created_at = DateTime.Now,
                            KeyTime = request.KeyTimes[i],
                            Note = request.Note,
                            Created_by = request.UserId,
                            Status = Status.INACTIVE,
                            ServiceId = request.ServiceIds[i]

                        };
                        _context.BookingDetails.Add(detail);
                        _context.SaveChanges();



                    }



                }
                response.Code = "200";
                response.Message = "Booking successfully";

                return response;


                //}
                //else
                //{
                //    return null;
                //}


            }
            catch (DbUpdateException)
            {
                response.Code = "200";
                response.Message = "Booking failed, try it again!";

                return response;
            }
        }

        public async Task<BookingResponse> UpdateBookingDetailStatus(BookingDetailStatusRequest request)
        {
            BookingResponse response = new();
            try
            {
                var detail = await _context.BookingDetails.FirstOrDefaultAsync(x => x.Id == request.bookingDetailID);
                var bookingId = detail.BookingId;
                var booking = await _context.Bookings.Where(x => x.Id == bookingId).FirstOrDefaultAsync();

                detail.Status = request.status;
                _context.SaveChanges();
                var count = _context.BookingDetails.Where(x => x.BookingId == bookingId && x.Status == Status.INACTIVE).Count();
                if (count == 0)
                {
                    booking.Status = Status.DONE;
                }


                response.Code = "200";
                response.Message = "Update successfully";
                await _context.SaveChangesAsync();
                return response;


            }
            catch (Exception e)
            {
                response = new()
                {

                    Code = "203",
                    Message = "Update failed"
                };
            }

            return response;
        }

        public async Task<BookingResponse> DeleteBooking(string bookingId, Guid userId)
        {
            BookingResponse response = new BookingResponse();

            try
            {
                Booking obj = _context.Bookings.Find(bookingId);
                if (obj != null)
                {
                    obj.Deleted_by = userId;
                    obj.Deleted_at = DateTime.Parse(DateTime.Now.ToString("yyyy/MMM/dd"));
                    obj.Status = Status.INACTIVE;

                    await _context.SaveChangesAsync();

                    response.Code = "200";
                    response.Message = "Delete booking successfully";

                    return response;
                }
                else
                {
                    response.Code = "200";
                    response.Message = "Can not find that booking";

                    return response;
                }

            }
            catch (DbUpdateException)
            {

                response.Code = "200";
                response.Message = "Delete booking failed";

                return response;
            }
        }

        public async Task<ListBookingResponse> GetBookingList(PaginationFilter filter)
        {
            ListBookingResponse response = new();
            List<BookingDTO> listDto = new();

            PaginationDTO paginationDTO = new();

            string orderBy = filter._order.ToString();

            if (orderBy.Equals("1"))
            {
                orderBy = "descending";
            }
            else if (orderBy.Equals("-1"))
            {
                orderBy = "ascending";
            }
            var pagedData = await _context.Bookings
                    .OrderBy(filter._by + " " + orderBy)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();

            var totalRecords = await _context.Bookings.CountAsync();

            if (!pagedData.Any())
            {
                response.Content = null;
                response.Code = "200";
                response.Message = "There aren't any bookings in DB";
            }
            else
            {
                foreach (var x in pagedData)
                {
                    listDto.Add(mapToBookingDto(x));
                }
                response.Content = listDto;
                response.Message = "SUCCESS";
                response.Code = "200";

            }
            var totalPages = ((double)totalRecords / (double)filter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            paginationDTO.CurrentPage = filter.PageNumber;
            paginationDTO.PageSize = filter.PageSize;
            paginationDTO.TotalPages = roundedTotalPages;
            paginationDTO.TotalRecords = totalRecords;

            response.Pagination = paginationDTO;



            return response;
        }

        public async Task<ListBookingResponse> GetBookingListForUser(PaginationFilter filter, Guid userId)
        {
            ListBookingResponse response = new();
            List<BookingDTO> listDto = new();

            PaginationDTO paginationDTO = new();

            string orderBy = filter._order.ToString();

            if (orderBy.Equals("1"))
            {
                orderBy = "descending";
            }
            else if (orderBy.Equals("-1"))
            {
                orderBy = "ascending";
            }
            var pagedData = await _context.Bookings
                .Where(x => x.UserId == userId)
                .OrderBy(filter._by + " " + orderBy)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var totalRecords = await _context.Bookings.Where(x => x.UserId == userId).CountAsync();

            if (!pagedData.Any())
            {
                response.Content = null;
                response.Code = "200";
                response.Message = "There aren't any bookings in DB";
            }
            else
            {
                foreach (var x in pagedData)
                {
                    listDto.Add(mapToBookingDto(x));
                }
                response.Content = listDto;
                response.Message = "SUCCESS";
                response.Code = "200";

            }
            var totalPages = ((double)totalRecords / (double)filter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            paginationDTO.CurrentPage = filter.PageNumber;
            paginationDTO.PageSize = filter.PageSize;
            paginationDTO.TotalPages = roundedTotalPages;
            paginationDTO.TotalRecords = totalRecords;

            response.Pagination = paginationDTO;



            return response;

        }

        public async Task<BookingResponse> UpdateBooking(BookingRequest request)
        {
            BookingResponse response = new BookingResponse();

            try
            {
                Booking obj = _context.Bookings.Where(g => g.Id == request.Id).SingleOrDefault();
                if (obj != null)
                {
                    obj.Total = request.Total;
                    obj.Date = request.Date;
                    obj.Status = request.Status;
                    obj.Updated_at = DateTime.Parse(DateTime.Now.ToString("yyyy/MMM/dd"));
                    obj.Updated_by = request.UserId;

                    await _context.SaveChangesAsync();
                    response.Code = "200";
                    response.Message = "Update booking successfully";

                    return response;

                }
                else
                {
                    response.Code = "200";
                    response.Message = "Can not find that booking";

                    return response;
                }

            }
            catch (DbUpdateException)
            {

                response.Code = "200";
                response.Message = "Update booking failed";

                return response;
            }
        }

        public async Task<BookingDetailResponse> GetBookingDetail(int bookingId)
        {
            BookingDetailResponse response = new BookingDetailResponse();
            List<BookingDetailDTO> listDto = new();

            try
            {
                List<BookingDetail> details =
                    await _context.BookingDetails.Where(g => g.BookingId.Equals(bookingId)).ToListAsync();

                if (details != null)
                {
                    foreach (var x in details)
                    {
                        listDto.Add(MapToBookingDetailDto(x));
                    }

                    response.Details = listDto;
                    response.Code = "200";
                    response.Message = "GetBookingDetail successfully";

                    return response;
                }
                else
                {
                    response.Details = null;
                    response.Code = "200";
                    response.Message = "Can not find any booking detail of that booking";

                    return response;
                }
            }
            catch (DbUpdateException)
            {
                response.Details = null;
                response.Code = "200";
                response.Message = "GetBookingDetail failed";

                return response;
            }
        }

        public async Task<ListBookingDTOResponse> GetBookingListForDentist(PaginationFilter filter, int dentistId)
        {
            ListBookingDTOResponse response = new();
            PaginationDTO paginationDto = new();
            List<BookingDTO> listDto = new();


            var orderBy = filter._order.ToString();

            if (orderBy.Equals("1"))
            {
                orderBy = "descending";
            }
            else if (orderBy.Equals("-1"))
            {
                orderBy = "ascending";
            }

            dynamic pagedData = null;


            pagedData = await (from booking in _context.Bookings
                               join bookingDetail in _context.BookingDetails on booking.Id equals bookingDetail.BookingId
                               where bookingDetail.DentistId == dentistId && booking.Status == Status.CONFIRMED
                               select new { booking })
                .OrderBy("booking." + "Date" + " " + orderBy)
                .Distinct()
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();



            var totalRecords = await (from booking in _context.Bookings
                                      join bookingDetail in _context.BookingDetails on booking.Id equals bookingDetail.BookingId
                                      where bookingDetail.DentistId == dentistId && booking.Status == Status.CONFIRMED
                                      select new { booking }).Distinct().CountAsync();

            if (pagedData == null)
            {
                response.Content = null;
                response.Code = "200";
                response.Message = "There aren't any bookings in DB";
            }
            else
            {
                foreach (var x in pagedData)
                {
                    listDto.Add(mapToBookingDto(x.booking, dentistId));
                }
                response.Content = listDto;
                response.Message = "SUCCESS";
                response.Code = "200";
            }

            var totalPages = ((double)totalRecords / (double)filter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            paginationDto.CurrentPage = filter.PageNumber;
            paginationDto.PageSize = filter.PageSize;
            paginationDto.TotalPages = roundedTotalPages;
            paginationDto.TotalRecords = totalRecords;

            response.Pagination = paginationDto;


            return response;
        }

        private BookingDTO mapToBookingDto(Booking booking)
        {
            BookingDTO bookingDto = new BookingDTO()
            {
                Date = booking.Date,
                Id = booking.Id,
                Status = booking.Status,
                Total = booking.Total,
                UserId = booking.UserId,
                User = MapToDTO(booking.UserId),
                CreateAt = booking.Created_at,
                Detail = GetDetailFromBooking(booking.Id)

            };
            return bookingDto;
        }


        private BookingDTO mapToBookingDto(Booking booking, int dentistId)
        {
            BookingDTO bookingDto = new BookingDTO()
            {
                Date = booking.Date,
                Id = booking.Id,
                Status = booking.Status,
                Total = booking.Total,
                UserId = booking.UserId,
                User = MapToDTO(booking.UserId),
                Detail = GetDetailFromBooking(booking.Id, dentistId)

            };
            return bookingDto;
        }
        private BookingDetailDTO MapToBookingDetailDto(BookingDetail bookingDetail)
        {
            var dentistName = _context.Users.Where(x => x.DentistId == bookingDetail.DentistId).FirstOrDefault();
            var bookingStatus = _context.Bookings.FirstOrDefault(x => x.Id == bookingDetail.BookingId);

            var detailDto = new BookingDetailDTO()
            {
                Id = bookingDetail.Id,
                Note = bookingDetail.Note,
                Services = GetService(bookingDetail.ServiceId),
                Status = bookingDetail.Status,
                DentistName = dentistName.FirstName + " " + dentistName.LastName,
                BookingStatus = bookingStatus.Status,
                KeyTime = bookingDetail.KeyTime

            };

            return detailDto;
        }



        private UserDTO MapToDTO(Guid userID)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userID);

            var userDto = new UserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
                Id = user.Id.ToString(),
                Email = user.Email,
                ImageUrl = user.Image

            };

            return userDto;
        }

        private DentistServiceDto GetService(int serviceId)
        {
            var result = _context.Services.FirstOrDefault(x => x.Id == serviceId);

            DentistServiceDto dto = new();
            dto.Id = result.Id;
            dto.ServiceName = result.Name;

            return dto;
        }

        public List<KeyTime> GetPostListKeyTime(int clinicId, int serviceId, DateTime date)
        {
            List<KeyTime> list = new();

            var details = (from t1 in _context.Bookings
                           join t2 in _context.BookingDetails
                           on t1.Id equals t2.BookingId
                           where t1.Date.Equals(date)
                           && t1.Status != Status.DECLINED
                           select t2).ToList();
            var dentists = (from t1 in _context.Dentists
                            join t2 in _context.Users
                            on t1.Id equals t2.DentistId
                            where t1.ClinicId == clinicId && t2.Status != Status.INACTIVE
                            select t1).ToList();
            int count = 0;
            foreach (var detail in details)
            {
                count = 0;
                foreach (var dentist in dentists)
                {
                    if (detail.ServiceId == serviceId && detail.DentistId == dentist.Id)
                    {
                        count++;
                        if (count == dentists.Count())
                        {
                            list.Add(detail.KeyTime);

                        }
                    }

                }
            }

            return list;


        }

        private List<BookingDtoDetail> GetDetailFromBooking(int bookingId, int dentistId)
        {
            List<BookingDtoDetail> list = new();


            var data = _context.BookingDetails.Where(x => x.BookingId == bookingId && x.DentistId == dentistId).ToList();


            foreach (var x in data)
            {
                var serviceName = _context.Services.FirstOrDefault(y => y.Id == x.ServiceId)?.Name;
                if (serviceName != null)
                {
                    BookingDtoDetail detail = new()
                    {
                        DetailID = x.Id,
                        KeyTime = x.KeyTime,

                    };
                    list.Add(detail);
                }
            }

            return list;
        }

        private List<BookingDtoDetail> GetDetailFromBooking(int bookingId)
        {
            List<BookingDtoDetail> list = new();


            var data = _context.BookingDetails.Where(x => x.BookingId == bookingId).ToList();


            foreach (var x in data)
            {
                var serviceName = _context.Services.FirstOrDefault(y => y.Id == x.ServiceId)?.Name;
                if (serviceName != null)
                {
                    BookingDtoDetail detail = new()
                    {
                        DetailID = x.Id,
                        KeyTime = x.KeyTime,

                    };
                    list.Add(detail);
                }
            }

            return list;
        }

        public async Task<BookingResponse> UpdateBookingStatus(BookingStatusRequest request)
        {
            BookingResponse response = null;
            try
            {
                var booking = _context.Bookings.FirstOrDefault(x => x.Id == request.bookingID);
                if (booking != null)
                {

                    booking.Status = request.status;
                    response = new()
                    {

                        Code = "200",
                        Message = "Update status succesfull"
                    };
                    await _context.SaveChangesAsync();
                }
                else
                {
                    response = new()
                    {

                        Code = "203",
                        Message = "Not found "
                    };
                }
            }
            catch (Exception e)
            {
                response = new()
                {

                    Code = "203",
                    Message = "Update failed"
                };
            }

            return response;
        }

        public async Task<BookingDetailResponse> GetDetailByDentistAndBooking(int dentistId, int bookingId)
        {
            BookingDetailResponse response = new BookingDetailResponse();
            List<BookingDetailDTO> listDto = new();

            try
            {
                List<BookingDetail> details =
                    await _context.BookingDetails.Where(g => g.BookingId.Equals(bookingId) && g.DentistId.Equals(dentistId)).ToListAsync();

                if (details != null)
                {
                    foreach (var x in details)
                    {
                        listDto.Add(MapToBookingDetailDto(x));
                    }

                    response.Details = listDto;
                    response.Code = "200";
                    response.Message = "GetBookingDetail successfully";

                    return response;
                }
                else
                {
                    response.Details = null;
                    response.Code = "200";
                    response.Message = "Can not find any booking detail of that booking";

                    return response;
                }
            }
            catch (DbUpdateException)
            {
                response.Details = null;
                response.Code = "200";
                response.Message = "GetBookingDetail failed";

                return response;
            }
        }

        public async Task<BookingResponse> DeleteBookingByUser(int bookingId)
        {
            BookingResponse response = new BookingResponse();

            try
            {
                Booking obj = _context.Bookings.Find(bookingId);
                if (obj != null && DateTime.Now < obj.Created_at.AddSeconds(120))
                {

                    _context.Bookings.Remove(obj);
                    _context.SaveChanges();

                    response.Code = "200";
                    response.Message = "Delete booking successfully";

                    return response;
                }
                else
                {
                    response.Code = "200";
                    response.Message = "Over limit time to delete booking!";

                    return response;
                }

            }
            catch (DbUpdateException)
            {

                response.Code = "200";
                response.Message = "Delete booking failed";

                return response;
            }
        }
    }
}
