﻿
using System.Runtime.InteropServices;

using TOAPI.Types;

namespace TOAPI.AviCap32
{
    public partial class Vfw
    {
        [DllImport("msvfw32.dll", EntryPoint = "InitVFW")]
        public static extern int InitVFW();


        /// Return Type: LONG->int
        [DllImport("msvfw32.dll", EntryPoint = "TermVFW")]
        public static extern int TermVFW();


         // 3    0 0000250A DrawDibBegin
        [DllImport("msvfw32.dll", EntryPoint = "DrawDibBegin")]
        public static extern int DrawDibBegin(System.IntPtr hdd, System.IntPtr hdc, int dxDest, int dyDest, ref BITMAPINFOHEADER lpbi, int dxSrc, int dySrc, uint wFlags);

         // 4    1 00009868 DrawDibChangePalette
         // 5    2 0000A07D DrawDibClose
         // 6    3 0000195D DrawDibDraw
         // 7    4 00009834 DrawDibEnd
         // 8    5 00009B2C DrawDibGetBuffer
         // 9    6 0000368C DrawDibGetPalette
         //10    7 000042E7 DrawDibOpen
         //11    8 000043AF DrawDibProfileDisplay
         //12    9 0000244E DrawDibRealize
         //13    A 0000233D DrawDibSetPalette
         //14    B 0000360D DrawDibStart
         //15    C 0000364D DrawDibStop
         //16    D 0000985E DrawDibTime

         //17    E 0000D169 GetOpenFileNamePreview
         //18    F 0000D169 GetOpenFileNamePreviewA
         //19   10 0000D135 GetOpenFileNamePreviewW
         //20   11 0000D183 GetSaveFileNamePreviewA
         //21   12 0000D14F GetSaveFileNamePreviewW

         //22   13 00003B7D ICClose
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICClose")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.SysInt)]
        public static extern int ICClose(System.IntPtr hic);

         //23   14 00004EFE ICCompress
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICCompress")]
        public static extern uint ICCompress(System.IntPtr hic, uint dwFlags, ref BITMAPINFOHEADER lpbiOutput, System.IntPtr lpData, ref BITMAPINFOHEADER lpbiInput, System.IntPtr lpBits, ref uint lpckid, ref uint lpdwFlags, int lFrameNum, uint dwFrameSize, uint dwQuality, ref BITMAPINFOHEADER lpbiPrev, System.IntPtr lpPrev);

         //24   15 00007F65 ICCompressorChoose
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICCompressorChoose")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool ICCompressorChoose(System.IntPtr hwnd, uint uiFlags, System.IntPtr pvIn, System.IntPtr lpData, ref COMPVARS pc, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] System.Text.StringBuilder lpszTitle);

        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICCompressorChoose")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool ICCompressorChoose(System.IntPtr hwnd, uint uiFlags, ref BITMAPINFO pvIn, System.IntPtr lpData, ref COMPVARS pc, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] System.Text.StringBuilder lpszTitle);


        //25   16 00005F3E ICCompressorFree
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICCompressorFree")]
        public static extern void ICCompressorFree(ref COMPVARS pc);

         //26   17 00004F68 ICDecompress
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICDecompress")]
        public static extern uint ICDecompress(System.IntPtr hic, uint dwFlags, ref BITMAPINFOHEADER lpbiFormat, System.IntPtr lpData, ref BITMAPINFOHEADER lpbi, System.IntPtr lpBits);

         //27   18 0000191D ICDraw
         //28   19 000022C1 ICDrawBegin

         //29   1A 00005AF1 ICGetDisplayFormat
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICGetDisplayFormat")]
        public static extern System.IntPtr ICGetDisplayFormat(System.IntPtr hic, ref BITMAPINFOHEADER lpbiIn, ref BITMAPINFOHEADER lpbiOut, int BitDepth, int dx, int dy);

         //30   1B 0000513D ICGetInfo

        //31   1C 000063E6 ICImageCompress
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICImageCompress")]
        public static extern System.IntPtr ICImageCompress(System.IntPtr hic, uint uiFlags, ref BITMAPINFO lpbiIn, System.IntPtr lpBits, ref BITMAPINFO lpbiOut, int lQuality, ref int plSize);

         //32   1D 00006676 ICImageDecompress
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICImageDecompress")]
        public static extern System.IntPtr ICImageDecompress(System.IntPtr hic, uint uiFlags, ref BITMAPINFO lpbiIn, System.IntPtr lpBits, ref BITMAPINFO lpbiOut);

         //33   1E 000036D0 ICInfo
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICInfo")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool ICInfo(uint fccType, uint fccHandler, ref ICINFO lpicinfo);

         //34   1F 000056D1 ICInstall

         //35   20 00003C81 ICLocate
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICLocate")]
        public static extern System.IntPtr ICLocate(uint fccType, uint fccHandler, ref BITMAPINFOHEADER lpbiIn, ref BITMAPINFOHEADER lpbiOut, ushort wFlags);

         //36   21 00008F30 ICMThunk32

         //37   22 000039C5 ICOpen
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICOpen")]
        public static extern System.IntPtr ICOpen(uint fccType, uint fccHandler, uint wMode);

         //38   23 000040C2 ICOpenFunction
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "ICOpenFunction")]
        public static extern System.IntPtr ICOpenFunction(uint fccType, uint fccHandler, uint wMode, FARPROC lpfnHandler);

         //39   24 00005881 ICRemove
         //40   25 000018B5 ICSendMessage
         //41   26 00006304 ICSeqCompressFrame
         //42   27 0000626F ICSeqCompressFrameEnd
         //43   28 00005FFB ICSeqCompressFrameStart

         //44   29 00012B2B MCIWndCreate
         //45   2A 00012B2B MCIWndCreateA
         //46   2B 00012A79 MCIWndCreateW
         //47   2C 000129DD MCIWndRegisterClass
         //48   2D 0000AEAE StretchDIB

         // 2   2E 00004666 VideoForWindowsVersion
        [System.Runtime.InteropServices.DllImport("msvfw32.dll", EntryPoint = "VideoForWindowsVersion", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern uint VideoForWindowsVersion();

    }
}
