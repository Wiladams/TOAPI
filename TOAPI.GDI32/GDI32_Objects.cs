﻿using System;
using System.Runtime.InteropServices;

using TOAPI.Types;


namespace TOAPI.GDI32
{
    public partial class GDI32
    {
        // Object Handle management
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(SafeHandle hDC, IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern int DeleteObject(IntPtr hObject);

        //[DllImport("gdi32.dll")]
        //public static extern int DeleteObject([In] SafeHandle hObject);

        // GetObjectType
        [DllImport("gdi32.dll")]
        public static extern int GetObjectType(IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern int GetObjectType([In] SafeHandle hObject);

        // GetStockObject
        [DllImport("gdi32.dll")]
        public static extern IntPtr GetStockObject(int nIndex);

        // EnumObjects
        // GetCurrentObject
        [DllImport("gdi32.dll", EntryPoint = "GetCurrentObject")]
        public static extern IntPtr GetCurrentObject([In] IntPtr hdc, int type);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern int GetObject([In] IntPtr h, int c, IntPtr pv);
        
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "GetObjectA")]
        public static extern int GetObjectA([System.Runtime.InteropServices.InAttribute()] System.IntPtr h, int c, System.IntPtr pv);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "GetObjectW")]
        public static extern int GetObjectW([System.Runtime.InteropServices.InAttribute()] System.IntPtr h, int c, System.IntPtr pv);

        //        280  117 0001FD81 EnumObjects
        [DllImport("gdi32.dll")]
        public static extern int EnumObjects([In] SafeHandle hdc, int nObjectType, EnumObjectsProc lpObjectFunc, IntPtr lParam);

        //         43   2A 0000B926 CreateBrushIndirect
        [DllImport("gdi32.dll", EntryPoint = "CreateBrushIndirect")]
        public static extern IntPtr CreateBrushIndirect([In] ref LOGBRUSH32 plbrush);

        
        // Bitmap specific objects
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetObject(IntPtr hObject, int nSize, ref BITMAP bm);

        public static IntPtr GetBitmap(IntPtr hObject, ref BITMAP bm)
        {
            IntPtr objectPtr = GetObject(hObject, Marshal.SizeOf(typeof(BITMAP)), ref bm);
            return objectPtr;
        }


        // Font Objects
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetObject(IntPtr hObject, int nSize, [In, Out] LOGFONT lf);

        public static int GetObject(IntPtr hObject, LOGFONT lp)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(LOGFONT)), lp);
        }
    }
}
