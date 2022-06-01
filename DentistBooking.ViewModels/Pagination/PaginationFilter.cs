﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.Pagination
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string _by { get; set; }
        public int _order { get; set; }
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
            _by = "Created_at";
            _order = 1;
        }
        public PaginationFilter(int pageNumber, int pageSize, string sortBy, int orderBy)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
            _by = String.IsNullOrEmpty(sortBy) ? "Created_at" : sortBy;
            _order = orderBy > 0 ? 1 : orderBy;
        }
    }
}
