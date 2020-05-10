using Google.Protobuf;

namespace CSharpEtcd
{
    public static class Util
    {
        public static string FromProto(this ByteString bstr)
        {
            return bstr.ToStringUtf8();
        }
        public static ByteString ToProto(this string str)
        {
            return ByteString.CopyFromUtf8(str);
        }
        public static byte[] FromBytesProto(this ByteString bstr)
        {
            return bstr.ToByteArray();
        }
        public static ByteString ToProto(this byte[] str)
        {
            return ByteString.CopyFrom(str);
        }
    }
}
