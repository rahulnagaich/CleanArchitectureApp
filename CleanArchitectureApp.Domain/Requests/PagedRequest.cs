using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Requests
{
    public class PagedRequest : BaseRequest
    {
        private const int maxPageSize = 100;

        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
    }

}
