﻿

namespace TOAPI.Types
{
    using System;
    using System.Runtime.InteropServices;
    
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate int MMIOPROC([MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder lpmmioinfo, int uMsg, IntPtr lParam1, IntPtr lParam2);
    
    //public delegate void TIMERPROC(IntPtr param0, uint param1, IntPtr param2, uint param3);
    public delegate void TIMECALLBACK(uint uTimerID, uint uMsg, uint dwUser, uint dw1, uint dw2);


    /// <summary>
    /// This is the delegate for a windows procedure
    /// </summary>
    //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
    //public delegate IntPtr MessageProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);


    /// <summary>Generic FARPROC return for various Kernel32 calls
    /// 
    /// </summary>
    /// <returns></returns>
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate int FARPROC();

    /// <summary>Delegate for User32 SetTimer
    /// Some needed delegates
    /// </summary>
    public delegate void TimerProc(IntPtr hWnd, int msg, IntPtr wParam, uint lParam);

    /// <summary>Enumerating GDI Objects
    /// </summary>
    /// <param name="lpLogObject"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate int EnumObjectsProc(IntPtr lpLogObject, IntPtr lParam);


    /// <summary>
    /// For User32.EnumDesktopWindows
    /// </summary>
    /// <param name="param0"></param>
    /// <param name="param1"></param>
    /// <returns></returns>
    public delegate int EnumWindowsProc(IntPtr param0, IntPtr param1);

    public delegate int MONITORENUMPROC(IntPtr param0, IntPtr param1, ref RECT param2, IntPtr param3);

    /// <summary> 
    /// The routine called to start a fiber.
    /// </summary>
    /// <param name="lpFiberParameter"></param>
    public delegate void PFIBER_START_ROUTINE(IntPtr lpFiberParameter);

}
