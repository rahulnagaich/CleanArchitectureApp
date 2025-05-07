using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Requests
{
    public class FilteredRequest : PagedRequest
    {
        public string? FilterColumn { get; set; }
        public string? FilterValue { get; set; }
    }
}
