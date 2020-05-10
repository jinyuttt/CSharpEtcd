using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpEtcd.Entity
{
   public class MemberUpdateResponse
    {
      
        public ResponseHeader Header { get; set; }
        
        public Member[] Members { get; internal set; }
    }
}
