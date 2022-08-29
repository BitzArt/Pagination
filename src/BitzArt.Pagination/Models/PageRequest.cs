namespace BitzArt.Pagination
{
    public class PageRequest
    {
        public virtual int Offset { get; set; }
        public virtual int Limit { get; set; }

        public PageRequest() : this(0, 100) { }

        public PageRequest(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }
    }
}
