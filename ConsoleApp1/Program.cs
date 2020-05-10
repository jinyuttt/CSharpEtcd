using dotnet_etcd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var etcdClient = new EtcdClient("127.0.0.1:2379");
          
        }
    }
}
