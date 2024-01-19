namespace StaySphere.Domain.Pagination
{
    public class PagenationMetaData
    {
        public int Totalcount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
