using CSharpEtcd;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var etcdClient =new  CSharpEtcdClient("https://localhost:2379");
            etcdClient.Put("jin", "yu");
          string v=  etcdClient.GetVal("jin");
          
        }
    }
}
