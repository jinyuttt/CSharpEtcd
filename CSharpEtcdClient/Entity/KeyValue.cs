namespace CSharpEtcd.Entity
{
    public class KeyValue
    {
      
        public long Version { get; set; }
        
        public long ModRevision { get; set; }
       
        public long CreateRevision { get; set; }
       
        public string Key { get; set; }
      
        public long Lease { get; set; }
      
        public string Value { get; set; }

        
        public int CalculateSize { get; set; }
    }
}