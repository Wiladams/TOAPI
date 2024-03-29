﻿using System;
using System.Runtime.InteropServices;

using TOAPI.Types;


namespace TOAPI.GDI32
{
    public partial class GDI32
    {
        // Device Context Related functions
        //         48   2F 0000BCD9 CreateDCA
        //         49   30 0000BE99 CreateDCW
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(
            string lpszDriver,
            string lpszDevice,
            string lpszOutput,
            IntPtr lpInitData);

        //         47   2E 0000620C CreateCompatibleDC
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC([In] SafeHandle hDC);

        //        147   92 00008EAC DPtoLP
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC([In] IntPtr hdc);

        //[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        //private static extern IntPtr CreateIC(string lpszDriverName, string lpszDeviceName, string lpszOutput, int /*DEVMODE*/ lpInitData);


        //        438  1B5 00005EA6 GetDeviceCaps
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int GetDeviceCaps([In] SafeHandle hDC, int nIndex);

        //        469  1D4 00007830 GetLayout
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "GetLayout")]
        public static extern int GetLayout([In] SafeHandle hdc);

        //        633  278 000113EA SetLayout
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "SetLayout")]
        public static extern int SetLayout([In] SafeHandle hdc, int l);

        // Device Context Region Management
        [DllImport("gdi32.dll", EntryPoint = "SetMetaRgn")]
        public static extern int SetMetaRgn([In] SafeHandle hdc);

        [DllImport("gdi32.dll", EntryPoint = "GetMetaRgn")]
        public static extern int GetMetaRgn([In] SafeHandle hdc, [In] IntPtr hrgn);

        [DllImport("gdi32.dll", EntryPoint = "GetRandomRgn")]
        public static extern int GetRandomRgn([In] SafeHandle hdc, [In] IntPtr hrgn, int i);

        [DllImport("gdi32.dll", EntryPoint = "GetClipRgn")]
        public static extern int GetClipRgn([In] SafeHandle hdc, [In] IntPtr hrgn);

        [DllImport("gdi32.dll", EntryPoint = "IntersectClipRect")]
        public static extern int IntersectClipRect([In] SafeHandle hdc, int left, int top, int right, int bottom);

        [DllImport("gdi32.dll", EntryPoint = "OffsetClipRgn")]
        public static extern int OffsetClipRgn([In] SafeHandle hdc, int x, int y);

        [DllImport("gdi32.dll", EntryPoint = "SelectClipRgn")]
        public static extern int SelectClipRgn([In] SafeHandle hdc, [In] IntPtr hrgn);

    }
}
