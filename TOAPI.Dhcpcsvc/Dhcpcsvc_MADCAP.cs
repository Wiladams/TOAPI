﻿using System;
using System.Runtime.InteropServices;

namespace TOAPI.Dhcpcsvc
{
    public partial class MADCAP
    {
        public static int gMADCAPVersion;
        public static bool gMADCAPDidStartup;

        static MADCAP()
        {
            gMADCAPDidStartup = (0 == McastApiStartup(ref gMADCAPVersion));
        }

         //58   39 000221FF McastApiCleanup
        [DllImport("dhcpcsvc.dll", EntryPoint = "McastApiCleanup")]
        public static extern void McastApiCleanup();

         //59   3A 00022189 McastApiStartup
        [DllImport("dhcpcsvc.dll", EntryPoint = "McastApiStartup")]
        public static extern int McastApiStartup(ref int Version);

         //60   3B 00022209 McastEnumerateScopes
        [DllImport("dhcpcsvc.dll", EntryPoint = "McastEnumerateScopes")]
        public static extern uint McastEnumerateScopes(ushort AddrFamily, 
            [MarshalAs(UnmanagedType.Bool)] bool ReQuery, 
            ref MCAST_SCOPE_ENTRY pScopeList, 
            ref uint pScopeLen, 
            [Out] out uint pScopeCount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AddrFamily"></param>
        /// <param name="ReQuery"></param>
        /// <param name="pScopeList"></param>
        /// <param name="pScopeLen"></param>
        /// <param name="pScopeCount"></param>
        /// <returns></returns>
        /// <remarks>
        /// This one uses a IntPtr for the scopList so that IntPtr.Zero can be passed
        /// in.  This allows passing "null" to the call, so that the Enumeration will return
        /// the size of the buffer needed to actually return the scopes.
        /// </remarks>
        [DllImport("dhcpcsvc.dll", EntryPoint = "McastEnumerateScopes")]
        public static extern uint McastEnumerateScopes(ushort AddrFamily,
            [MarshalAs(UnmanagedType.Bool)] bool ReQuery,
            IntPtr pScopeList,
            ref uint pScopeLen,
            [Out] out uint pScopeCount);

        //61   3C 0002239E McastGenUID
        [DllImport("dhcpcsvc.dll", EntryPoint = "McastGenUID")]
        public static extern uint McastGenUID([In] ref MCAST_CLIENT_UID pRequestID);

        //62   3D 000228A9 McastReleaseAddress
        [DllImport("dhcpcsvc.dll", EntryPoint = "McastReleaseAddress")]
        public static extern uint McastReleaseAddress(ushort AddrFamily, 
            [In] ref MCAST_CLIENT_UID pRequestID, 
            [In] ref MCAST_LEASE_REQUEST pReleaseRequest);

        //63   3E 00022687 McastRenewAddress
        [DllImport("dhcpcsvc.dll", EntryPoint = "McastRenewAddress")]
        public static extern uint McastRenewAddress(ushort AddrFamily, 
            [In] ref MCAST_CLIENT_UID pRequestID, 
            [In] ref MCAST_LEASE_REQUEST pRenewRequest, 
            ref MCAST_LEASE_RESPONSE pRenewResponse);
        
        //64   3F 000223C8 McastRequestAddress
        [DllImport("dhcpcsvc.dll", EntryPoint = "McastRequestAddress")]
        public static extern uint McastRequestAddress(ushort AddrFamily, 
            [In] ref MCAST_CLIENT_UID pRequestID, 
            [In] ref MCAST_SCOPE_CTX pScopeCtx, 
            [In] ref MCAST_LEASE_REQUEST pAddrRequest, 
            ref MCAST_LEASE_RESPONSE pAddrResponse);

    }
}
