using System.Collections.Generic;
using DentistBooking.Data.Entities;
using DentistBooking.ViewModels.Pagination;

namespace DentistBooking.ViewModels.System.Users
{
    public class UserResponse
    {
        public IEnumerable<UserDTO> Content { get; set; }

        public string Code { get; set; }
        public string Message { get; set; }

        public PaginationDTO Pagination { get; set; }    
    }
}