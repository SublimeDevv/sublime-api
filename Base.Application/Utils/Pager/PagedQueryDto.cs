namespace Base.Application.Utils.Pager
{
    public class PagedQueryDto
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}