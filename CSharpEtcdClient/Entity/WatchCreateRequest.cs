namespace CSharpEtcd.Entity
{
    public class WatchCreateRequest
    {
      
        public bool ProgressNotify { get; set; }
       
        public long StartRevision { get; set; }
       
        public string RangeEnd { get; set; }
        
        public string Key { get; set; }
       
        public bool PrevKv { get; set; }
       
        public long WatchId { get; set; }
       
        public bool Fragment { get; set; }
      
        public Types.FilterType[] Filters { get; }
    }
}