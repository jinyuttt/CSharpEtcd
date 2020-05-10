using dotnet_etcd;
using System;

namespace CSharpEtcd
{
    /// <summary>
    /// 管理客户端使用
    /// </summary>
    internal class ClientMgr
    {
        private static readonly Lazy<ClientMgr> mgr = new Lazy<ClientMgr>();

        public static ClientMgr  Instance
        {
            get { return mgr.Value; }
        }
        private EtcdClient etcdClient = null;
        public EtcdClient  Client
        {
            get;set;
        }

        public EtcdClient GetEtcdClient()
        {
            return etcdClient;
        }
    }
}
