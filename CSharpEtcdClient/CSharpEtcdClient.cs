using System;
using System.Collections.Generic;
using System.Threading;
using CSharpEtcd.Entity;
using dotnet_etcd;


namespace CSharpEtcd
{

    public class CSharpEtcdClient
    {
         EtcdClient client = null;
        public CSharpEtcdClient(string connectionString, int port = 2379, string username = "", string password = "",
              string caCert = "", string clientCert = "", string clientKey = "", bool publicRootCa = false)
        {
            client = new EtcdClient(connectionString, port, username, password, caCert, clientCert, clientKey, publicRootCa);
            ClientMgr.Instance.Init ( client);
        }

        public EtcdClient GetEtcdClient()
        {
            return ClientMgr.Instance.GetEtcdClient();
        }

        public PutResponse Put(string key,string value)
        {
            var rsp=  client.Put(new Etcdserverpb.PutRequest() { Key = key.ToProto(), Value = value.ToProto() });
            return rsp.FromProto();
        }

        public PutResponse Put(PutRequest request)
        {
            var req = request.ToProto();
            var rsp = client.Put(req);
            return rsp.FromProto();
        }

        public string GetVal(string key)
        {
          
            var rsp = client.GetVal(key);
            return rsp;
        }

        public RangeResponse Get(string key)
        {

            var rsp = client.Get(key);
            return rsp.FromProto();
        }

        public RangeResponse GetRange(string key)
        {

            var rsp = client.GetRange(key);
            return rsp.FromProto();
        }
        public IDictionary<string,string> GetRangeVal(string key)
        {

            var rsp = client.GetRangeVal(key);
            return rsp;
        }

        public DeleteRangeResponse Delete(string key)
        {

            var rsp = client.Delete(key);
            return rsp.FromProto();
        }

        public DeleteRangeResponse DeleteRange(string key)
        {

            var rsp = client.DeleteRange(key);
            return rsp.FromProto();
        }
        public void Watch(string key)
        {
            WatchRequest request = new WatchRequest()
            {
                CreateRequest = new WatchCreateRequest()
                {
                    Key = key
                }
            };
            Watch(request);
        }
        public void Watch(WatchRequest request)
        {
            var req = request.ToProto();
            client.Watch(req, new Action<Etcdserverpb.WatchResponse>(p =>
            {

            }));
        }

        public MemberAddResponse MemberAdd(MemberAddRequest  request)
        {
            var req = request.ToProto();
            var rsp= client.MemberAdd(req);
            return rsp.FromProto();
        }
        public MemberAddResponse MemberAdd(string[] peerURLs)
        {
            MemberAddRequest request = new MemberAddRequest() { PeerURLs = peerURLs };
            return MemberAdd(request);
        }
        public MemberRemoveResponse MemberRemove(MemberRemoveRequest request)
        {
            var req = request.ToProto();
            var rsp = client.MemberRemove(req);
            return rsp.FromProto();
        }
        public MemberRemoveResponse MemberRemove(ulong id)
        {
            MemberRemoveRequest request = new MemberRemoveRequest() { ID = id };
            return MemberRemove(request);
        }

        public MemberUpdateResponse MemberUpdate(MemberUpdateRequest request)
        {
            var req = request.ToProto();
            var rsp = client.MemberUpdate(req);
            return rsp.FromProto();
        }

        public MemberListResponse MemberUpdate(MemberListRequest request)
        {
            var req = request.ToProto();
            var rsp = client.MemberList(req);
            return rsp.FromProto();
        }

        public LeaseGrantResponse LeaseGrant(LeaseGrantRequest request)
        {
            var req = request.ToProto();
            var rsp = client.LeaseGrant(req);
            return rsp.FromProto();
        }

        public void LeaseKeepAlive(long   leaseid)
        {
            var request = new LeaseKeepAliveRequest() { ID = leaseid };
            var req = request.ToProto();
            var rsp = client.LeaseKeepAlive(req, new Action<Etcdserverpb.LeaseKeepAliveResponse>(p =>
            {

            }), CancellationToken.None);
          
        }

        public void LeaseRevoke(long leaseid)
        {
            var request = new LeaseRevokeRequest() { ID = leaseid };
            var req = request.ToProto();
            client.LeaseRevoke(req);
          
        }
        public LeaseTimeToLiveResponse LeaseTimeToLive(LeaseTimeToLiveRequest request)
        {
          
            var req = request.ToProto();
            var rsp= client.LeaseTimeToLive(req);
            return rsp.FromProto();
        }

        public LockResponse Lock(LockRequest request)
        {

            var req = request.ToProto();
            var rsp = client.Lock(req);
            return rsp.FromProto();
        }
        public  void Lock(string key)
        {

       
           client.Lock(key);
           
        }
        public UnlockResponse UnLock(UnlockRequest request)
        {

            var req = request.ToProto();
            var rsp = client.Unlock(req);
            return rsp.FromProto();
        }
        public UnlockResponse UnLock(string key)
        {
            var rsp = client.Unlock(key);
            return rsp.FromProto();
        }
    }

  
}
