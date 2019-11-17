
using System.Runtime.InteropServices;

namespace TOAPI.Dhcpcsvc
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct MCAST_SCOPE_CTX
    {
        public IPNG_ADDRESS ScopeID;    /// IPNG_ADDRESS->_IPNG_ADDRESS
        public IPNG_ADDRESS Interface;  /// IPNG_ADDRESS->_IPNG_ADDRESS
        public IPNG_ADDRESS ServerID;   /// IPNG_ADDRESS->_IPNG_ADDRESS
    }
}
