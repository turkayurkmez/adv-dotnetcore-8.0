namespace customTagBuilder.Models
{
    public class PagingInfo
    {
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount => (int)Math.Ceiling(TotalItems / (double)PageSize);
    }
}
