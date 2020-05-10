namespace CSharpEtcd.Entity
{
    public class MemberListResponse
    {
       
        public ResponseHeader Header { get; set; }
       
        public Member[] Members { get; internal set; }
    }
}