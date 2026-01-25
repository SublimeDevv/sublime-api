namespace Base.Infraestructure.Utils
{
    public static class IQueryableExtentions
    {
        public static IQueryable<T> ApplyQueryOptions<T>(this IQueryable<T> queryable, int page, int size)
        {
            return queryable.Skip((page - 1) * size).Take(size);
        }
    }
}
