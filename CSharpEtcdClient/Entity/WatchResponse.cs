namespace CSharpEtcd.Entity
{
    public  class WatchResponse
    {
       
        public string CancelReason { get; set; }
        
        public long CompactRevision { get; set; }
        
        public bool Canceled { get; set; }
        
        public bool Created { get; set; }
        
        public long WatchId { get; set; }
       
        public ResponseHeader Header { get; set; }
        
        public WatchEvent[] Events { get; }
        
        public bool Fragment { get; set; }

    }
}
