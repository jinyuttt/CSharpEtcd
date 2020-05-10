namespace CSharpEtcd.Entity
{
    public class LockRequest
    {
      
        public string Name { get; set; }
       
        public long Lease { get; set; }
    }
}
