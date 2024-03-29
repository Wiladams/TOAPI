﻿using System;
using System.Runtime.InteropServices;
using System.Text;

using TOAPI.Types;

namespace TOAPI.User32
{
    public partial class User32
    {
        //private delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        //[DllImport("user32.dll")]
        //private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip,
        //   EnumMonitorsDelegate lpfnEnum, IntPtr dwData);
        
        
        // MonitorEnumProc - Used with EnumDisplayMonitors
        public delegate int MonitorEnumProc(IntPtr hMonitor, IntPtr hDCMonitor, ref RECT lprcMonitor, IntPtr dwData);


        // EnumDisplaySettings
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, [Out] out DEVMODE lpDevMode);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int EnumDisplaySettingsEx(string lpszDeviceName, int iModeNum, 
            [Out] out DEVMODE lpDevMode, int dwFlags);

        // ChangeDisplaySettingsEx
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ChangeDisplaySettingsEx(string lpszDeviceName, 
            ref DEVMODE lpDevMode, IntPtr hwnd, uint dwflags, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ChangeDisplaySettingsEx(string lpszDeviceName,
            IntPtr lpDevMode, IntPtr hwnd, uint dwflags, IntPtr lParam);

        // EnumDisplayMonitors
        [DllImport("user32.dll", EntryPoint = "EnumDisplayMonitors")]
        public static extern int EnumDisplayMonitors(IntPtr hdc, ref RECT lprcClip,
            MonitorEnumProc lpfnEnum, IntPtr dwData);

        [DllImport("user32.dll", EntryPoint = "EnumDisplayMonitors")]
        public static extern int EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip,
            MonitorEnumProc lpfnEnum, IntPtr dwData);


        // GetMonitorInfo
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMonitorInfo(IntPtr hmonitor, ref MONITORINFOEX info);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMonitorInfo(IntPtr hmonitor, [In, Out]MONITORINFO info);

        // MonitorFromPoint
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr MonitorFromPoint(POINT pt, int dwFlags);

        // MonitorFromRect
        [DllImport("user32.dll", EntryPoint = "MonitorFromRect")]
        public static extern IntPtr MonitorFromRect([In] ref RECT lprc, uint dwFlags);

        // MonitorFromWindow
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, int dwFlags);



        // EnumDisplayDevices
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int EnumDisplayDevices(string lpDevice, uint iDevNum,
            ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);
    }
}
