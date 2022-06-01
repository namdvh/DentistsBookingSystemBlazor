using DentistBooking.ViewModels.Pagination;
using System.Collections.Generic;

namespace DentistBooking.ViewModels.System.Dentists
{
    public class DentistResponse
    {
        public IEnumerable<DentistDTO> Content { get; set; }
        public string Code { get; set; }
        
        public string Message { get; set; }
        
        public List<string> Errors { get; set; }
        
        public PaginationDTO Pagination { get; set; }    


    }
}
