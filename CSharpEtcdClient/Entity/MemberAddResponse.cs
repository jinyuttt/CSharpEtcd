using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpEtcd.Entity
{
   public class MemberAddResponse
    {
      
        public ResponseHeader Header { get; set; }
      
        public Member Member { get; set; }
     
        public Member[] Members { get; internal set; }
    }
}
