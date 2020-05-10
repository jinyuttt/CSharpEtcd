namespace CSharpEtcd.Entity
{
    public class MemberRemoveResponse
    {
       
        public ResponseHeader Header { get; set; }
       
        public Member[] Members { get; internal set; }
    }
}