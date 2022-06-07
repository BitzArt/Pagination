namespace BitzArt.Pagination.Models
{
    public class PageRequest
    {
        public virtual int Offset { get; set; }
        public virtual int Limit { get; set; }

        public PageRequest()
        {
        }

        public PageRequest(int offset = 0, int limit = 100)
        {
            Offset = offset;
            Limit = limit;
        }
    }
}
