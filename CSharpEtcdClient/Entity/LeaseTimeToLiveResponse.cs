namespace CSharpEtcd.Entity
{
    public class LeaseTimeToLiveResponse
    {
       
        public long TTL { get; set; }
        
        public long ID { get; set; }
      
        public ResponseHeader Header { get; set; }
        
        public string[] Keys { get; internal set; }
     
        public long GrantedTTL { get; set; }
    }
}
