namespace CSharpEtcd.Entity
{
    public class DeleteRangeResponse
    {
       
        public ResponseHeader Header { get; set; }
      
        public long Deleted { get; set; }
       
        public KeyValue[] PrevKvs { get; internal set; }

       
        public int CalculateSize { get; set; }
    }
}
