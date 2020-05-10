namespace CSharpEtcd.Entity
{
    public class Member
    {
       
        public string[] PeerURLs { get; internal set; }
       
        public string Name { get; set; }
       
        public ulong ID { get; set; }
    
        public bool IsLearner { get; set; }
       
        public string[] ClientURLs { get; internal set; }
    }
}