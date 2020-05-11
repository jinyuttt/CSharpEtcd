using dotnet_etcd;
using System;
using System.Threading;
using System.Collections.Concurrent;
namespace CSharpEtcd
{
    /// <summary>
    /// 管理客户端使用
    /// </summary>
    internal class ClientMgr
    {
        private static readonly Lazy<ClientMgr> mgr = new Lazy<ClientMgr>();

        private object lock_obj = new object();

        private ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();

        public static ClientMgr  Instance
        {
            get { return mgr.Value; }
        }
        private EtcdClient etcdClient = null;
       

        public EtcdClient GetEtcdClient()
        {
            try
            {
                etcdClient.Put("testclient", "client");
                return etcdClient;
            }
            catch(Exception ex)
            {
                //
                var client = GetClient();
                if(client!=null)
                {
                    etcdClient = client;
                }
                return etcdClient;
            }
        }
        private EtcdClient GetClient()
        {
            if (dic.Count > 0)
            {
                var lst = new string[dic.Keys.Count];
                dic.Keys.CopyTo(lst, 0);
                foreach (var p in lst)
                {
                    try
                    {
                        EtcdClient client = new EtcdClient(p);
                        return client;
                    }
                    catch
                    {

                    }
                }
            }
            return null;
        }

        public void Init(EtcdClient client)
        {
            lock (lock_obj)
            {
                if (etcdClient == null)
                {
                    etcdClient = client;
                    Start();
                }
            }
        }

        private  void Start()
        {
              Thread th = new Thread(() =>
              {
                  while (true)
                  {
                      try
                      {
                          var rsp = etcdClient.MemberList(new Etcdserverpb.MemberListRequest());
                          foreach (var p in rsp.Members)
                          {
                              foreach (var client in p.ClientURLs)
                              {
                                  dic[client] = null;
                              }
                          }
                          Thread.Sleep(10000);
                      }
                      catch(Exception ex)
                      {
                          GetEtcdClient();
                      }
                  }
              });
            th.IsBackground = true;
            th.Name = "MemberList";
            th.Start();
        }
    }
}
