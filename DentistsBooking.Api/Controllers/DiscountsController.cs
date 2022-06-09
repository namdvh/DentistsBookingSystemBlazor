using DentistBooking.Application.System.Discounts;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Discounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DentistsBooking.Api.Controllers
{
    [ApiController]
    //Authorize]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        [Route("api/discounts")]
        public async Task<IActionResult> GetAllDiscounts([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter._by, filter._order);
            ListDiscountResponse result = await _discountService.GetDiscountList(validFilter);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/discounts")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DiscountResponse result = await _discountService.CreateDiscount(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/discounts")]
        public async Task<IActionResult> UpdateDiscount([FromBody] DiscountRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DiscountResponse result = await _discountService.UpdateDiscount(request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/discounts/{discountId}")]
        public async Task<IActionResult> DeleteDiscount([FromRoute] int discountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DiscountResponse result = await _discountService.DeleteDiscount(discountId);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/discounts/{discountId}")]
        public async Task<IActionResult> GetDiscount([FromRoute] int discountId)
        {
            DiscountDTO result = await _discountService.GetDiscount(discountId);
            return Ok(result);
        }

        [HttpDelete()]
        [Route("api/discounts/apply/{discountId}")]
        public async Task<IActionResult> ApplyForAll([FromRoute] int discountId)
        {
            var result = await _discountService.ApplyForAll(discountId);
            return Ok(result);
        }
    }
}
