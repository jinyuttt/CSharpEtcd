using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpEtcd.Entity
{
   public class RangeResponse
    {
       
        public KeyValue[] Kvs { get; set; }
        
        public ResponseHeader Header { get; set; }
       
        public long Count { get; set; }
       
        public bool More { get; set; }

        
        public int CalculateSize { get; set; }
    }
}
