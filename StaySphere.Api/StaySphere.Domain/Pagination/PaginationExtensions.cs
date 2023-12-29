using StaySphere.Domain.Common;

namespace StaySphere.Domain.Pagination
{
    public static class PaginationExtensions
    {
        public static PaginatedList<T> ToPaginatedList<T>(
            this IQueryable<T> source,
            int pageSize,
            int pageNumber) where T : EntityBase
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
