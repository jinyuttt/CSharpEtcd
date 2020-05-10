namespace CSharpEtcd.Entity
{
    public class ResponseHeader
    {
        public ulong MemberId { get; set; }

        public ulong ClusterId { get; set; }

        public ulong RaftTerm { get; set; }

        public long Revision { get; set; }


       public  int CalculateSize { get; set; }
    }
}
