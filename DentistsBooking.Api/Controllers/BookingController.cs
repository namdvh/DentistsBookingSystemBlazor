using System.Collections.Generic;
using System.Threading.Tasks;
using DentistBooking.Application.System.Bookings;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistsBooking.Api.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    //[Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookingResponse result = await _bookingService.CreateBooking(request);
            return Ok(result);
        }


        [HttpGet("getbookingdetail")]
        public async Task<IActionResult> GetBookingDetail([FromQuery] int bookingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookingDetailResponse result = await _bookingService.GetBookingDetail(bookingId);
            return Ok(result);
        }

        [HttpGet("getUnavailableKeyTime")]
        public async Task<IActionResult> GetBookingDetail([FromQuery] int clinicId, int serviceId, System.DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<KeyTime> result = await _bookingService.GetPostListKeyTime(clinicId, serviceId, date);
            return Ok(result);
        }

        [HttpGet("dentist/{dentistID}")]
        public async Task<IActionResult> GetBookingListDentist([FromQuery] PaginationFilter filter, int dentistID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter._by, filter._order);

            var result = await _bookingService.GetBookingListForDentist(validFilter, dentistID);

            return Ok(result);
        }
    }


}