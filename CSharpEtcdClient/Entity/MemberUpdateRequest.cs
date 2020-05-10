using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpEtcd.Entity
{
   public class MemberUpdateRequest
    {
     
        public ulong ID { get; set; }
      
        public string[] PeerURLs { get; set; }
    }
}
