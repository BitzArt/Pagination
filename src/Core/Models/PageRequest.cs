namespace BitzArt.Pagination.Models
{
    public class PageRequest
    {
        public virtual int Skip { get; set; }
        public virtual int Take { get; set; }

        public PageRequest(int skip = 0, int take = 100)
        {
            Skip = skip;
            Take = take;
        }
    }
}
