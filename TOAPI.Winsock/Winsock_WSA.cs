﻿using System;
using System.Runtime.InteropServices;

using TOAPI.Kernel32;



namespace TOAPI.Winsock
{

    public partial class Winsock
    {
        // 37    D 0000A9E9 WSAAccept
        
        // 38    E 00006AC5 WSAAddressToStringA
        // 39    F 00003072 WSAAddressToStringW
        
        // 40   10 0001FB74 WSAAdvertiseProvider
        
        // Use getaddrinfo instead of these
        //102   11 00016203 WSAAsyncGetHostByAddr
        //103   12 00016131 WSAAsyncGetHostByName
        
        //105   13 000162B4 WSAAsyncGetProtoByName
        //104   14 00016386 WSAAsyncGetProtoByNumber
        //107   15 00015FCF WSAAsyncGetServByName
        //106   16 000160A7 WSAAsyncGetServByPort
        
        //101   17 0001A116 WSAAsyncSelect

        //108   18 0001640A WSACancelAsyncRequest
        [DllImport("ws2_32.dll", EntryPoint = "WSACancelAsyncRequest", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSACancelAsyncRequest([In] IntPtr hAsyncTaskHandle);

        //116   1A 0000A6C6 WSACleanup
        [DllImport("ws2_32.dll", EntryPoint = "WSACleanup", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSACleanup();

        // 41   1B 0000BE44 WSACloseEvent
        [DllImport("ws2_32.dll", EntryPoint = "WSACloseEvent", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool WSACloseEvent(IntPtr hEvent);


        // 42   1C 0000DA1B WSAConnect
        // 43   1D 0001B09C WSAConnectByList
        // 44   1E 0001B93D WSAConnectByNameA
        // 45   1F 0001B5E4 WSAConnectByNameW

        // 46   20 0000A801 WSACreateEvent
        [DllImport("ws2_32.dll", EntryPoint = "WSACreateEvent", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr WSACreateEvent();

        // 47   21 0001521E WSADuplicateSocketA
        // 48   22 00015190 WSADuplicateSocketW
        
        // 49   23 00019029 WSAEnumNameSpaceProvidersA
        [DllImport("ws2_32.dll", EntryPoint = "WSAEnumNameSpaceProvidersA", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSAEnumNameSpaceProvidersA(ref uint lpdwBufferLength, IntPtr lpnspBuffer);



        // 50   24 000190E9 WSAEnumNameSpaceProvidersExA
        // 58   25 00019149 WSAEnumNameSpaceProvidersExW

        // 59   26 00019089 WSAEnumNameSpaceProvidersW
        [DllImport("ws2_32.dll", EntryPoint = "WSAEnumNameSpaceProvidersW", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSAEnumNameSpaceProvidersW(ref uint lpdwBufferLength, IntPtr lpnspBuffer);

        // 60   27 00006C45 WSAEnumNetworkEvents
        // 61   28 00015549 WSAEnumProtocolsA
        // 62   29 0000C2FA WSAEnumProtocolsW
        // 63   2A 0000A75B WSAEventSelect

        //111   2B 000035C9 WSAGetLastError
        [DllImport("ws2_32.dll", EntryPoint = "WSAGetLastError", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSAGetLastError();

        // 64   2C 0000A4F5 WSAGetOverlappedResult
        // 65   2D 00018898 WSAGetQOSByName
        
        // 66   2E 00019BF0 WSAGetServiceClassInfoA
        // 67   2F 000198E1 WSAGetServiceClassInfoW
        // 68   30 000194D1 WSAGetServiceClassNameByClassIdA
        // 69   31 000196D9 WSAGetServiceClassNameByClassIdW
        // 72   34 00019B71 WSAInstallServiceClassA
        // 73   35 000192FB WSAInstallServiceClassW

        // 70   32 00011464 WSAHtonl
        [DllImport("ws2_32.dll", EntryPoint = "WSAHtonl", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSAHtonl([In] IntPtr s, uint hostlong, [Out] out uint lpnetlong);

        // 71   33 00011561 WSAHtons
        [DllImport("ws2_32.dll", EntryPoint = "WSAHtons", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSAHtons([In] IntPtr s, ushort hostshort, [Out] out ushort lpnetshort);

        // 74   36 00003C69 WSAIoctl
        [DllImport("ws2_32.dll", EntryPoint = "WSAIoctl", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSAIoctl(IntPtr s, 
            int dwIoControlCode, 
            [In] IntPtr lpvInBuffer, int cbInBuffer, 
            IntPtr lpvOutBuffer, int cbOutBuffer, 
            [Out] out int lpcbBytesReturned,
            [In] ref OVERLAPPED lpOverlapped,
            [In] FileIOCompletionRoutine lpCompletionRoutine);

        
        // 75   38 0001BB04 WSAJoinLeaf
        // 76   39 0000ABBA WSALookupServiceBeginA
        // 77   3A 000053D6 WSALookupServiceBeginW
        // 78   3B 00005AF5 WSALookupServiceEnd
        // 79   3C 0000B0CD WSALookupServiceNextA
        // 80   3D 000058A0 WSALookupServiceNextW
        // 81   3E 0000B646 WSANSPIoctl

        // 82   3F 00011464 WSANtohl
        // 83   40 00011561 WSANtohs
        
        // 84   41 0001A1A7 WSAPoll
        // 85   42 0001FE62 WSAProviderCompleteAsyncCall
        // 86   43 0000CA6A WSAProviderConfigChange
        // 87   44 000072B5 WSARecv
        // 88   45 00018A6B WSARecvDisconnect
        // 89   46 00018AF6 WSARecvFrom
        // 90   47 000193E6 WSARemoveServiceClass

        // 91   48 0000A814 WSAResetEvent
        [DllImport("ws2_32.dll", EntryPoint = "WSAResetEvent", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WSAResetEvent(IntPtr hEvent);

        // 92   49 00004EE9 WSASend
        [DllImport("ws2_32.dll", EntryPoint = "WSASend")]
        public static extern int WSASend([In] IntPtr s, 
            [In] WSABUF[] lpBuffers, int dwBufferCount, 
            [Out] out int lpNumberOfBytesSent, 
            int dwFlags, 
            [In] ref OVERLAPPED lpOverlapped, 
            [In] FileIOCompletionRoutine lpCompletionRoutine);

        // 93   4A 0001A381 WSASendDisconnect
        [DllImport("ws2_32.dll", EntryPoint = "WSASendDisconnect", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSASendDisconnect(IntPtr s, ref WSABUF lpOutboundDisconnectData);

        // 94   4B 0001A4CB WSASendMsg
        // 95   4C 0001A40C WSASendTo

        // 96   4E 0000BF57 WSASetEvent
        [DllImport("ws2_32.dll", EntryPoint = "WSASetEvent", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool WSASetEvent([In] IntPtr hEvent);

        //112   4F 00002DF9 WSASetLastError
        [DllImport("ws2_32.dll", EntryPoint = "WSASetLastError", CallingConvention = CallingConvention.StdCall)]
        public static extern void WSASetLastError([In] int iError);

        // 97   50 00019C82 WSASetServiceA
        // 98   51 00019A21 WSASetServiceW
        
        // 99   52 0000C2A4 WSASocketA
        [DllImport("ws2_32.dll", EntryPoint = "WSASocketA", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr WSASocketA(int af, int type, int protocol, IntPtr lpProtocolInfo, int g, uint dwFlags);

        //100   53 00004174 WSASocketW
        [DllImport("ws2_32.dll", EntryPoint = "WSASocketW", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr WSASocketW(int af, int type, int protocol, IntPtr lpProtocolInfo, int g, uint dwFlags);

        //115   54 00007372 WSAStartup
        [DllImport("ws2_32.dll", EntryPoint = "WSAStartup", CallingConvention = CallingConvention.StdCall)]
        public static extern int WSAStartup(ushort wVersionRequested, ref WSAData lpWSAData);

        //117   55 00006614 WSAStringToAddressA
        //118   56 0000672D WSAStringToAddressW
        //119   57 0001F5B9 WSAUnadvertiseProvider
        //120   59 0000BEA1 WSAWaitForMultipleEvents
        // 24   5A 0001D692 WSApSetPostRoutine

        // Obsolete
        //113   19 0001458C WSACancelBlockingCall
        //114   37 000145DB WSAIsBlocking
        //109   4D 0001462E WSASetBlockingHook
        //110   58 00014683 WSAUnhookBlockingHook

    }
}
