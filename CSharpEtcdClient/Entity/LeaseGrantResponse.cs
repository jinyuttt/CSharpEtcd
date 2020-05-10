namespace CSharpEtcd.Entity
{
    public   class LeaseGrantResponse
    {
        
        public long ID { get; set; }
       
        public ResponseHeader Header { get; set; }
       
        public string Error { get; set; }
      
        public long TTL { get; set; }
    }
}
