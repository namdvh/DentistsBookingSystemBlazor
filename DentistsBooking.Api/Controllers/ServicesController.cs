using DentistBooking.Application.System.Services;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DentistsBooking.Api.Controllers
{
    [Route("api/services")]
    [ApiController]
    //[Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClinics([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter._by, filter._order);
            var result = await _serviceService.GetServiceList(validFilter);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateClinic([FromBody] AddServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _serviceService.CreateService(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClinic([FromBody] ServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _serviceService.UpdateService(request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{serviceId}")]
        public async Task<IActionResult> DeleteClinic([FromRoute] int serviceId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _serviceService.DeleteService(serviceId);
            return Ok(result);
        }

        [HttpGet]
        [Route("{serviceId}")]
        public async Task<IActionResult> GetService([FromRoute] int serviceId)
        {
            ServiceDto result = await _serviceService.GetService(serviceId);
            return Ok(result);
        }
    }
}
