
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpEtcd.Entity
{
  public  class WatchRequest
    {
     
        public WatchProgressRequest ProgressRequest { get; set; }
      
        public RequestUnionOneofCase RequestUnionCase { get; }
       
        public WatchCancelRequest CancelRequest { get; set; }
      
        public WatchCreateRequest CreateRequest { get; set; }

    }
}
