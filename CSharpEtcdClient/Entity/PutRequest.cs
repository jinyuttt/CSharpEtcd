namespace CSharpEtcd.Entity
{
    public class PutRequest
    {
     
        public bool PrevKv { get; set; }
      
        public long Lease { get; set; }
       
        public string Value { get; set; }
       
        public string Key { get; set; }
       
        public bool IgnoreLease { get; set; }
       
        public bool IgnoreValue { get; set; }

      
        public int CalculateSize { get; set; }
    }
}
