using DentistBooking.Data.DataContext;
using DentistBooking.Data.Entities;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Discounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.Application.System.Discounts
{
    public class DiscountService : IDiscountService
    {
        private readonly DentistDBContext _context;

        public DiscountService(DentistDBContext context)
        {
            _context = context;
        }
        public async Task<ListDiscountResponse> GetDiscountList(PaginationFilter filter)
        {
            ListDiscountResponse response = new();
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
            List<Discount> pagedData;

            pagedData = await _context.Discounts
               .OrderBy(filter._by + " " + orderBy)
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();



            var totalRecords = await _context.Discounts.CountAsync(x => x.status != Data.Enum.Status.INACTIVE);

            if (!pagedData.Any())
            {
                response.Content = null;
                response.Code = "200";
                response.Message = "There aren't any discounts in DB";
            }
            else
            {
                List<DiscountDTO> result = new List<DiscountDTO>();
                foreach (Discount x in pagedData)
                {
                    result.Add(MapToDTO(x));
                }
                response.Content = result;
                response.Message = "SUCCESS";
                response.Code = "200";

            }
            var totalPages = ((double)totalRecords / (double)filter.PageSize);


            var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            paginationDTO.CurrentPage = filter.PageNumber;

            paginationDTO.PageSize = filter.PageSize;

            paginationDTO.TotalPages = roundedTotalPages;
            paginationDTO.TotalRecords = totalRecords;

            response.Pagination = paginationDTO;



            return response;

        }

        public async Task<DiscountResponse> CreateDiscount(DiscountRequest request)
        {
            DiscountResponse response = new DiscountResponse();
            try
            {
                Discount discount = new Discount()
                {
                    Title = request.Title,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Description = request.Description,
                    Percent = request.Percent,
                    Amount = request.Amount,
                    status = Data.Enum.Status.ACTIVE,
                    Created_at = DateTime.Parse(DateTime.Now.ToString("yyyy/MMM/dd")),
                    Created_by = request.UserId,
                    ApplyForAll = false
                };

                _context.Discounts.Add(discount);
                await _context.SaveChangesAsync();

                response.Code = "200";
                response.Message = "Create discount successfully";

                return response;
            }
            catch (DbUpdateException)
            {
                response.Code = "200";
                response.Message = "Create discount failed";

                return response;
            }

        }
        public async Task<DiscountResponse> UpdateDiscount(DiscountRequest request)
        {
            DiscountResponse response = new DiscountResponse();

            try
            {
                Discount obj = await _context.Discounts.Where(g => g.Id == request.Id).SingleOrDefaultAsync();
                if (obj != null)
                {
                    obj.Title = request.Title;
                    obj.StartDate = request.StartDate;
                    obj.EndDate = request.EndDate;
                    obj.Description = request.Description;
                    obj.Percent = request.Percent;
                    obj.Amount = request.Amount;
                    obj.Updated_at = DateTime.Parse(DateTime.Now.ToString("yyyy/MMM/dd"));
                    obj.Updated_by = request.UserId;

                    await _context.SaveChangesAsync();
                    response.Code = "200";
                    response.Message = "Update discount successfully";

                    return response;

                }
                else
                {
                    response.Code = "200";
                    response.Message = "Can not find that discount";

                    return response;
                }

            }
            catch (DbUpdateException)
            {

                response.Code = "200";
                response.Message = "Update discount failed";

                return response;
            }

        }

        public async Task<DiscountResponse> DeleteDiscount(int discountId)
        {
            DiscountResponse response = new DiscountResponse();

            try
            {
                Discount obj = await _context.Discounts.FindAsync(discountId);
                if (obj != null)
                {
                    if (obj.status == Data.Enum.Status.INACTIVE)
                    {
                        obj.Deleted_at = null;
                        obj.status = Data.Enum.Status.ACTIVE;
                    }
                    else
                    {
                        obj.Deleted_at = DateTime.Parse(DateTime.Now.ToString("yyyy/MMM/dd"));
                        obj.status = Data.Enum.Status.INACTIVE;

                    }


                    await _context.SaveChangesAsync();

                    response.Code = "200";
                    response.Message = "Delete clinic successfully";

                    return response;
                }
                else
                {
                    response.Code = "200";
                    response.Message = "Can not find that discount";

                    return response;
                }

            }
            catch (DbUpdateException)
            {

                response.Code = "200";
                response.Message = "Delete discount failed";

                return response;
            }
        }

        public async Task<DiscountDTO> GetDiscount(int discountId)
        {

            try
            {
                Discount obj = await _context.Discounts.FindAsync(discountId);
                if (obj != null)
                {
                    var result = MapToDTO(obj);


                    return result;
                }
                return null;

            }
            catch (DbUpdateException)
            {

                return null;
            }
        }

        public async Task<bool> ApplyForAll(int discountId)
        {

            try
            {
                Discount obj = await _context.Discounts.FindAsync(discountId);
                if (obj != null)
                {
                    if (obj.ApplyForAll == true)
                    {
                        obj.ApplyForAll = false;
                    }
                    else
                    {
                        obj.ApplyForAll = true;
                    }
                    await _context.SaveChangesAsync();


                    return true;
                }
                return false;

            }
            catch (DbUpdateException)
            {

                return false;
            }
        }

        public DiscountDTO MapToDTO(Discount discount)
        {
            DiscountDTO discountDTO = new DiscountDTO()
            {
                Id = discount.Id,
                Description = discount.Description,
                Title = discount.Title,
                Amount = discount.Amount,
                Percent = discount.Percent,
                ApplyForAll = discount.ApplyForAll,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                status = discount.status


            };
            return discountDTO;
        }
    }
}
