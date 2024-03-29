﻿using System;
using System.Runtime.InteropServices;

using TOAPI.Types;

namespace TOAPI.GDI32
{
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void LINEDDAPROC(int param0, int param1, System.IntPtr param2);

    public partial class GDI32
    {
        // Setting current drawing pen position
        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveToEx([In] SafeHandle hDC, int x, int y, IntPtr lppoint);

        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveToEx([In] SafeHandle hDC, int x, int y, ref POINT point);


        // AngleArc
        [DllImport("gdi32.dll", EntryPoint = "AngleArc")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AngleArc([In] SafeHandle hdc, int x, int y, uint r, float StartAngle, float SweepAngle);

         //12    B 00033380 Arc
        [DllImport("gdi32.dll", EntryPoint = "Arc")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Arc([In] SafeHandle hdc, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4);
        
        //13    C 00033467 ArcTo
        [DllImport("gdi32.dll", EntryPoint = "ArcTo")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ArcTo([In] SafeHandle hdc, int left, int top, int right, int bottom, int xr1, int yr1, int xr2, int yr2);



        // SetBoundsRect
        [DllImport("gdi32.dll", EntryPoint = "SetBoundsRect")]
        public static extern uint SetBoundsRect([In] SafeHandle hdc, [In] ref RECT lprect, [In] int flags);

        // This one allows us to set the RECT parameter to null
        [DllImport("gdi32.dll", EntryPoint = "SetBoundsRect")]
        public static extern uint SetBoundsRect([In] SafeHandle hdc, [In] IntPtr lprect, [In] int flags);

        // GetBoundsRect - gdi32
        [DllImport("gdi32.dll", EntryPoint = "GetBoundsRect")]
        public static extern uint GetBoundsRect([In] SafeHandle hdc, out RECT lprect, int flags);



        [DllImport("gdi32.dll", EntryPoint = "GetCurrentPositionEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentPositionEx([In] SafeHandle hdc, [Out] out POINT lppt);

        // Saving and restoring current drawing context
        // GdiFlush - gdi32
        [DllImport("gdi32.dll", EntryPoint = "GdiFlush")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiFlush();

        // SaveDC
        [DllImport("gdi32.dll", EntryPoint = "SaveDC")]
        public static extern int SaveDC([In] SafeHandle hdc);

        // RestoreDC
        [DllImport("gdi32.dll", EntryPoint = "RestoreDC")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RestoreDC([In] SafeHandle hdc, int nSavedDC);


        // Pixel manipulation
        [DllImport("gdi32.dll")]
        public static extern UInt32 GetPixel([In] SafeHandle hDC, int x, int y);

        [DllImport("gdi32.dll")]
        public static extern UInt32 SetPixel([In] SafeHandle hDC, 
            int x, int y, UInt32 color);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetPixelV([In] SafeHandle hDC, 
            int x, int y, UInt32 color);

        [DllImport("gdi32.dll", EntryPoint = "ExtFloodFill")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool ExtFloodFill([In] SafeHandle hdc, 
            int x, int y, UInt32 color, uint type);

        // Line Drawing
        [DllImport("gdi32.dll", EntryPoint = "LineDDA")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LineDDA(int xStart, int yStart, int xEnd, int yEnd, 
            LINEDDAPROC lpProc, IntPtr data);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LineTo([In] SafeHandle hDC, 
            int x, int y);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PolylineTo([In] SafeHandle hDC, 
            POINT[] pts, int cCount);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Polyline([In] SafeHandle hDC, 
            POINT[] llpt, int cPoints);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PolyPolyline([In] SafeHandle hDC, 
            POINT[] pts,
            int[] lpdwPolyPoints, int cCount);

        //        568  237 00034D66 PolyDraw
        [DllImport("gdi32.dll", EntryPoint = "PolyDraw")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PolyDraw([In] SafeHandle hdc, 
            POINT[] apt, byte[] aj, int cpt);



        // RECTs
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Rectangle([In] SafeHandle hDC, int left, int top, int right, int bottom);

        //        594  251 00020904 RoundRect
        [DllImport("gdi32.dll", EntryPoint = "RoundRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RoundRect([In] SafeHandle hdc, 
            int left, int top, int right, int bottom, 
            int width, int height);

        // Drawing Ellipses
        [DllImport("gdi32.dll", EntryPoint = "Ellipse")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Ellipse([In] SafeHandle hdc, int left, int top, int right, int bottom);

        // This one draws gradient RECTs
        [DllImport("gdi32.dll", EntryPoint = "GdiGradientFill", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GradientRectangle(
          [In] SafeHandle hdc,                   // handle to DC
          TRIVERTEX[] pVertex,        // array of vertices
          int dwNumVertex,         // number of vertices
          GRADIENT_RECT[] pMesh,               // array of gradients
          int dwNumMesh,           // size of gradient array
          int dwMode               // gradient fill mode
        );

        // This one draws gradient triangles
        [DllImport("gdi32.dll", EntryPoint = "GdiGradientFill", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GradientTriangle(
          [In] SafeHandle hdc,                   // handle to DC
          TRIVERTEX[] pVertex,        // array of vertices
          int dwNumVertex,         // number of vertices
          GRADIENT_TRIANGLE[] pMesh,               // array of gradients
          int dwNumMesh,           // size of gradient array
          int dwMode               // gradient fill mode
        );


        // Polygons
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int GetPolyFillMode([In] SafeHandle hdc);

        // SetPolyFillMode
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int SetPolyFillMode([In] SafeHandle hdc, int iPolyFillMode);

        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Polygon([In] SafeHandle hdc, POINT[] points, int numberOfPoints);

        // Bezier construction
        //        566  235 00034B95 PolyBezier
        [DllImport("gdi32.dll", EntryPoint = "PolyBezier")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PolyBezier([In] SafeHandle hdc,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] POINT[] apt, uint numberOfPoints);

        //        567  236 00034CB5 PolyBezierTo
        [DllImport("gdi32.dll", EntryPoint = "PolyBezierTo")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PolyBezierTo([In] SafeHandle hdc, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] POINT[] apt, 
            uint numberOfPoints);

        // Drawing Regions
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FillRgn([In] SafeHandle hdc, SafeHandle hrgn, IntPtr hbr);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FrameRgn([In] SafeHandle hdc, SafeHandle hrgn, IntPtr hbr, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvertRgn([In] SafeHandle hdc, SafeHandle hrgn);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PaintRgn([In] SafeHandle hdc, SafeHandle hrgn);


        #region Path Management
        //        2    1 0003439E AbortPath
        [DllImport("gdi32.dll", EntryPoint = "AbortPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AbortPath([In] SafeHandle hdc);
        
        // 18   11 000343F5 BeginPath
        [DllImport("gdi32.dll", ExactSpelling=true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BeginPath([In] SafeHandle hdc);

        // ClosePath
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CloseFigure")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool CloseFigure([System.Runtime.InteropServices.InAttribute()] SafeHandle hdc);

        //        223   DE 000344FE EndPath
        [DllImport("gdi32.dll", ExactSpelling=true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndPath([In] SafeHandle hdc);

        //        304  12F 00034555 FlattenPath
        [DllImport("gdi32.dll", EntryPoint = "FlattenPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlattenPath([In] SafeHandle hdc);

        // WidenPath
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "WidenPath")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool WidenPath([System.Runtime.InteropServices.InAttribute()] System.IntPtr hdc);

        //        670  29D 00034730 StrokePath
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StrokePath([In] SafeHandle hdc);

        //        301  12C 000347BC FillPath
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FillPath([In] SafeHandle hdc);

        //        669  29C 000346A4 StrokeAndFillPath
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StrokeAndFillPath([In] SafeHandle hdc);

        //        604  25B 0003444C SelectClipPath
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SelectClipPath([In] SafeHandle hdc, int op);

        //        489  1E8 00034677 GetPath
        [DllImport("gdi32.dll", EntryPoint = "GetPath")]
        public static extern int GetPath([In] SafeHandle hdc, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 3)]POINT[] points, 
            byte[] types, int numPoints);
        
        [DllImport("gdi32.dll", EntryPoint = "GetPath")]
        public static extern int GetPath([In] SafeHandle hdc, IntPtr apt, IntPtr aj, int cpt);

        //        559  22E 00034603 PathToRegion
        [DllImport("gdi32.dll", EntryPoint = "PathToRegion")]
        public static extern IntPtr PathToRegion([In] SafeHandle hdc);
        #endregion

        // SetDCPenColor
        [DllImport("gdi32.dll")]
        public static extern uint SetDCPenColor([In] SafeHandle hdc, UInt32 crColor);

        // GetDCPenColor
        [DllImport("gdi32.dll", EntryPoint = "GetDCPenColor")]
        public static extern uint GetDCPenColor([In] SafeHandle hdc);

        [DllImport("gdi32.dll")]
        public static extern uint SetDCBrushColor([In] SafeHandle hdc, UInt32 crColor);

        // GetDCBrushColor
        [DllImport("gdi32.dll", EntryPoint = "GetDCBrushColor")]
        public static extern uint GetDCBrushColor([In] SafeHandle hdc);


        // SetArcDirection
        [DllImport("gdi32.dll", EntryPoint = "SetArcDirection")]
        public static extern int SetArcDirection([In] SafeHandle hdc, int dir);

        // SetROP2
        [DllImport("gdi32.dll")]
        public static extern int SetROP2([In] SafeHandle hDC, int nDrawMode);

        // GetROP2
        [DllImport("gdi32.dll")]
        public static extern int GetROP2([In] SafeHandle hDC);

        // Background color and mode
        // SetBkColor
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int SetBkColor([In] SafeHandle hDC, UInt32 nBkColor);

        // GetBkColor
        [DllImport("gdi32.dll", EntryPoint = "GetBkColor")]
        public static extern uint GetBkColor([In] SafeHandle hdc);

        // SetBkMode
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int SetBkMode([In] SafeHandle hDC, int backgroundMixMode);

        // GetBkMode
        [DllImport("gdi32.dll", EntryPoint = "GetBkMode")]
        public static extern int GetBkMode([In] SafeHandle hdc);

        // SetMiterLimit
        [DllImport("gdi32.dll", EntryPoint = "SetMiterLimit")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetMiterLimit([In] SafeHandle hdc, float limit, IntPtr oldLimit);

        [DllImport("gdi32.dll", EntryPoint = "SetMiterLimit")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetMiterLimit([In] SafeHandle hdc, float limit, ref float oldLimit);

        // SetStretchBltMode
        [DllImport("gdi32.dll", EntryPoint = "SetStretchBltMode")]
        public static extern int SetStretchBltMode([In] SafeHandle hdc, int mode);

    }
}
