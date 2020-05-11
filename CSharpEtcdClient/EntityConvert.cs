
using Etcdserverpb;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Mvccpb;
using System.Linq;
using V3Lockpb;

namespace CSharpEtcd
{
    public  static  class EntityConvert
    {

        private static  Entity.KeyValue[] FromProto(this RepeatedField<KeyValue> repeated)
        {
            Entity.KeyValue[] array = new Entity.KeyValue[repeated.Count];
            for(int i=0;i<array.Length;i++)
            {
                array[i] = repeated[i].FromProto();
            }
            return array;
        }
        private static string[] FromProto(this RepeatedField<ByteString> repeated)
        {
            string[] array = new string[repeated.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = repeated[i].FromProto();
            }
            return array;
        }


        private static RepeatedField<WatchCreateRequest.Types.FilterType> ToProto(this Types.FilterType[]  filters)
        {
            RepeatedField<WatchCreateRequest.Types.FilterType> filterTypes = new RepeatedField<WatchCreateRequest.Types.FilterType>();
            foreach(var p in filterTypes)
            {
                var tmp = (WatchCreateRequest.Types.FilterType)(p);
                filterTypes.Add(tmp);
            }
            return filterTypes;
        }
        private static RepeatedField<string> ToProto(this string[] str)
        {
            RepeatedField<string> tmp = new RepeatedField<string>();
            foreach (var p in str)
            {
                tmp.Add(p);
            }
            return tmp;
        }

        #region KV
        public static Entity.PutResponse FromProto(this PutResponse response)
        {
            return new Entity.PutResponse()
            {
                Header = response.Header.FromProto(),
                PrevKv = response.PrevKv.FromProto()
            };
        }

        public static Entity.ResponseHeader FromProto(this ResponseHeader response)
        {
            return new Entity.ResponseHeader()
            {
                ClusterId = response.ClusterId,
                MemberId = response.MemberId,
                RaftTerm = response.RaftTerm,
                Revision = response.Revision,
                 CalculateSize=response.CalculateSize()
            };
        }
        public static Entity.KeyValue FromProto(this KeyValue response)
        {
            if (response != null)
            {
                return new Entity.KeyValue()
                {
                    CreateRevision = response.CreateRevision,
                    Key = response.Key.FromProto(),
                    Lease = response.Lease,
                    ModRevision = response.ModRevision,
                    Value = response.Value.FromProto(),
                    Version = response.Version,
                    CalculateSize = response.CalculateSize()
                };
            }
            return null;
        }

        public static PutRequest ToProto(this Entity.PutRequest  request)
        {
            return new PutRequest()
            {
                IgnoreLease = request.IgnoreLease,
                IgnoreValue = request.IgnoreValue,
                Key = request.Key.ToProto(),
                Lease = request.Lease,
                PrevKv = request.PrevKv,
                Value = request.Value.ToProto()
            };
        }
        public static Entity.RangeResponse FromProto(this  RangeResponse  response)
        {
            return new Entity.RangeResponse()
            {
                Count = response.Count,
                Header = response.Header.FromProto(),
                Kvs = response.Kvs.FromProto(),
                More = response.More,
                CalculateSize = response.CalculateSize()
            };

        }
        public static Entity.DeleteRangeResponse FromProto(this DeleteRangeResponse response)
        {
            return new Entity.DeleteRangeResponse()
            {
                Deleted = response.Deleted,
                Header = response.Header.FromProto(),
                  
                PrevKvs = response.PrevKvs.FromProto()
                   ,
                CalculateSize = response.CalculateSize()
            };

        }

        #endregion

        #region Watch
        public static WatchRequest ToProto(this Entity.WatchRequest request)
        {
            return new WatchRequest()
            {
                CancelRequest=request.CancelRequest.ToProto(),
                 CreateRequest=request.CreateRequest.ToProto(),
                  ProgressRequest=request.ProgressRequest.ToProto(),
                  
            };
        }
        public static WatchCancelRequest ToProto(this Entity.WatchCancelRequest request)
        {
            return new WatchCancelRequest()
            {

                WatchId=request.WatchId
            };
        }

       
        public static WatchProgressRequest ToProto(this Entity.WatchProgressRequest request)
        {
            return new WatchProgressRequest()
            {

                 
            };
        }

        public static WatchCreateRequest ToProto(this Entity.WatchCreateRequest request)
        {
            return new WatchCreateRequest()
            {
               
                Fragment=request.Fragment,
                 Key=request.Key.ToProto(),
                  PrevKv=request.PrevKv,
                   ProgressNotify=request.ProgressNotify,
                    RangeEnd=request.RangeEnd.ToProto(),
                     StartRevision=request.StartRevision,
                      WatchId=request.WatchId
            };
        }

        #endregion

        #region  Member
        public static MemberAddRequest ToProto(this Entity.MemberAddRequest request)
        {
            var tmp= new MemberAddRequest()
            {

                IsLearner = request.IsLearner,
                
                 
            };
            tmp.PeerURLs.AddRange(request.PeerURLs);
            return tmp;
        }

        public static MemberRemoveRequest ToProto(this Entity.MemberRemoveRequest request)
        {
           return  new MemberRemoveRequest()
            {

              ID=request.ID


            };
        }
        public static MemberUpdateRequest ToProto(this Entity.MemberUpdateRequest request)
        {
            var tmp= new MemberUpdateRequest()
            {

                ID = request.ID,
         


            };
            tmp.PeerURLs.AddRange(request.PeerURLs);
            return tmp;
        }
        public static MemberListRequest ToProto(this Entity.MemberListRequest request)
        {
            return new MemberListRequest();
        }


        public static Entity.MemberAddResponse FromProto(this MemberAddResponse  response)
        {
            var tmp = new Entity.MemberAddResponse()
            {
                  Header= response.Header.FromProto(),
                  Member=response.Member.FromProto(),
                  Members = response.Members.FromProto()
            };
          
            return tmp;
        }
       
        public static Entity.MemberRemoveResponse FromProto(this MemberRemoveResponse response)
        {
            var tmp = new Entity.MemberRemoveResponse()
            {
                Header = response.Header.FromProto(),
                Members = response.Members.FromProto()
            };

            return tmp;
        }
        public static Entity.MemberUpdateResponse FromProto(this MemberUpdateResponse response)
        {
            var tmp = new Entity.MemberUpdateResponse()
            {
                Header = response.Header.FromProto(),

                Members = response.Members.FromProto()
            };

            return tmp;
        }
        public static Entity.MemberListResponse FromProto(this MemberListResponse response)
        {
            var tmp = new Entity.MemberListResponse()
            {
                Header = response.Header.FromProto(),

                Members = response.Members.FromProto()
            };

            return tmp;
        }
        public static Entity.Member FromProto(this Member request)
        {
            var tmp = new Entity.Member()
            {

                ID = request.ID,
                IsLearner = request.IsLearner,
                Name = request.Name,
                 ClientURLs=request.ClientURLs.ToArray(),
                PeerURLs=request.PeerURLs.ToArray()

            };
        
            return tmp;
        }
      
        public static Entity.Member[] FromProto(this RepeatedField<Member>  members)
        {
            var tmp = new Entity.Member[members.Count];
            for(int i=0;i<tmp.Length;i++)
            {
                tmp[i] = FromProto(members[i]);
            }
            return tmp;
        }


        #endregion

        #region Lease
        public static LeaseGrantRequest ToProto(this Entity.LeaseGrantRequest request)
        {
            return new LeaseGrantRequest()
            {
                ID = request.ID,
                TTL = request.TTL
            };
        }
        public static Entity.LeaseGrantResponse FromProto(this LeaseGrantResponse response)
        {
            return new Entity.LeaseGrantResponse()
            {
                Error = response.Error,
                Header = response.Header.FromProto(),
                ID = response.ID,
                TTL = response.TTL
            };
        }

        public static LeaseKeepAliveRequest ToProto(this Entity.LeaseKeepAliveRequest request)
        {
            return new LeaseKeepAliveRequest()
            {
                ID = request.ID
            };
        }
        public static LeaseRevokeRequest ToProto(this Entity.LeaseRevokeRequest request)
        {
            return new LeaseRevokeRequest()
            {
                ID = request.ID
            };
        }
        public static LeaseTimeToLiveRequest ToProto(this Entity.LeaseTimeToLiveRequest request)
        {
            return new LeaseTimeToLiveRequest()
            {
                ID = request.ID,
                 Keys=request.Keys
            };
        }

        public static Entity.LeaseTimeToLiveResponse FromProto(this LeaseTimeToLiveResponse response)
        {
            return new Entity.LeaseTimeToLiveResponse()
            {
                GrantedTTL = response.GrantedTTL,
                Header = response.Header.FromProto(),
                ID = response.ID,
                TTL = response.TTL,
                Keys = response.Keys.FromProto()
            };
        }

        #endregion


        #region Lock
        public static LockRequest ToProto(this Entity.LockRequest request)
        {
            return new LockRequest()
            {
                Lease=request.Lease,
                 Name=request.Name.ToProto()
            };
        }

        public static Entity.LockResponse FromProto(this LockResponse response)
        {
            return new Entity.LockResponse()
            {
                Header=response.Header.FromProto(),
                 Key=response.Key.FromProto()
            };
        }
        public static UnlockRequest ToProto(this Entity.UnlockRequest request)
        {
            return new UnlockRequest()
            {
                Key=request.Key.ToProto()
            };
        }

        public static Entity.UnlockResponse FromProto(this UnlockResponse response)
        {
            return new Entity.UnlockResponse()
            {
                Header = response.Header.FromProto(),
               
            };
        }
        #endregion
    }
}
