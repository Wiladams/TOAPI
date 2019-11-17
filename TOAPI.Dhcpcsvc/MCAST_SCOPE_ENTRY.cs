
using System.Runtime.InteropServices;

namespace TOAPI.Dhcpcsvc
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct MCAST_SCOPE_ENTRY
    {
        MCAST_SCOPE_CTX ScopeCtx; 
        IPNG_ADDRESS LastAddr; 
        uint TTL;
        [MarshalAsAttribute(UnmanagedType.LPWStr)]
        public string ScopeDesc;
    }
}
