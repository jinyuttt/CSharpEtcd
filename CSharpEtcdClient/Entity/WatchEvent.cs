using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpEtcd.Entity
{
  public  class WatchEvent
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public WatchEventType Type { get; set; }
    }
}
