﻿namespace StaySphere.Domain.Responses
{
    public class GetBaseResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int TotalPages { get; set; }
    }
}
