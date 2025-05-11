namespace CleanArchitectureApp.Shared.Requests
{
    public class PagedRequest
    {
        // Pagination
        private const int maxPageSize = 100;
        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > maxPageSize ? maxPageSize : value;
        }

        // Sorting
        public string? OrderBy { get; set; } // e.g., "Name" or "Price"
        public string SortDirection { get; set; } = "DESC"; // ASC or DESC
        public string? SearchTerm { get; set; }
    }
}
