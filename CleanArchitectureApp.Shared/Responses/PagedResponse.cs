namespace CleanArchitectureApp.Shared.Responses
{
    public class PagedResponse<T> : BaseResponse<T>
    {
        private readonly List<T> data = []; 

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public new List<T> Data { get; set; } = new List<T>();

        public PagedResponse(List<T> data, int pageNumber, int pageSize, int count, string v)
        {
            Data = data ?? [];
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Message = string.Empty;
            Succeeded = true;
            Errors = [];
        }
    }
}
