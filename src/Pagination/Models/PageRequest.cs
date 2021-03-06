namespace BitzArt.Pagination.Models
{
    public class PageRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; }

        public PageRequest(int skip = 0, int take = 100)
        {
            Skip = skip;
            Take = take;
        }
    }
}
