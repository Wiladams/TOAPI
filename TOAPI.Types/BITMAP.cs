using System;
using System.Runtime.InteropServices;

namespace TOAPI.Types
{

    //[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    //public struct tagBITMAPINFOHEADER
    //{

    //    public uint biSize;

    //    public int biWidth;

    //    public int biHeight;

    //    public ushort biPlanes;

    //    public ushort biBitCount;

    //    public uint biCompression;

    //    public uint biSizeImage;

    //    public int biXPelsPerMeter;

    //    public int biYPelsPerMeter;

    //    public uint biClrUsed;

    //    public uint biClrImportant;
    //}



    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAP
    {
        public int bmType;
        public int bmWidth;
        public int bmHeight;
        public int bmWidthBytes;
        public ushort bmPlanes;
        public ushort bmBitsPixel;
        public IntPtr bmBits;
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPCOREHEADER
    {
        public uint bcSize;
        public ushort bcWidth;
        ushort bcHeight;
        ushort bcPlanes;
        ushort bcBitCount;

        public void Init()
        {
            uint bcSize = (uint)Marshal.SizeOf(typeof(BITMAPCOREHEADER));
        }

    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct BITMAPINFOHEADER
    {
        public int biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;

        public void Init()
        {
            biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
        }
    }


    //[Serializable]
    //[StructLayout(LayoutKind.Sequential)]
    //public struct BITMAPINFO
    //{
    //    public BITMAPINFOHEADER bmiHeader;
    //    public IntPtr bmiColors;

    //    public void Init()
    //    {
    //        bmiHeader.Init();
    //    }
    //}

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFO
    {
        public BITMAPINFOHEADER bmiHeader;

        
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
        public RGBQUAD[] bmiColors;      /// RGBQUAD[1]

        public void Init()
        {
            bmiHeader.Init();
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPCOREINFO
    {
        BITMAPCOREHEADER bmciHeader;
        /// RGBTRIPLE[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
        public RGBTRIPLE[] bmciColors;

        public void Init()
        {
            bmciHeader.Init();
        }
    }





    [Serializable]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct BITMAPV4HEADER
    {
        public int bV4Size;
        public int bV4Width;
        public int bV4Height;
        public ushort bV4Planes;
        public ushort bV4BitCount;
        public uint bV4V4Compression;
        public uint bV4SizeImage;
        public int bV4XPelsPerMeter;
        public int bV4YPelsPerMeter;
        public uint bV4ClrUsed;
        public uint bV4ClrImportant;

        // New for the version 4 Structure
        public uint bV4RedMask;
        public uint bV4GreenMask;
        public uint bV4BlueMask;
        public uint bV4AlphaMask;

        public uint bV4CSType;

        public CIEXYZTRIPLE bV4Endpoints;

        public uint bV4GammaRed;
        public uint bV4GammaGreen;
        public uint bV4GammaBlue;



        public void Init()
        {
            bV4Size = Marshal.SizeOf(this);
        }
    }


    [Serializable]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct BITMAPV5HEADER
    {
        public uint bV5Size;
        public int bV5Width;
        public int bV5Height;
        public ushort bV5Planes;
        public ushort bV5BitCount;
        public uint bV5Compression;
        public uint bV5SizeImage;
        public int bV5XPelsPerMeter;
        public int bV5YPelsPerMeter;
        public uint bV5ClrUsed;
        public uint bV5ClrImportant;
        public uint bV5RedMask;
        public uint bV5GreenMask;
        public uint bV5BlueMask;
        public uint bV5AlphaMask;
        public uint bV5CSType;
        public CIEXYZTRIPLE bV5Endpoints;
        public uint bV5GammaRed;
        public uint bV5GammaGreen;
        public uint bV5GammaBlue;
        public uint bV5Intent;
        public uint bV5ProfileData;
        public uint bV5ProfileSize;
        public uint bV5Reserved;
    }



    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CIEXYZTRIPLE
    {
        public CIEXYZ ciexyzRed;
        public CIEXYZ ciexyzGreen;
        public CIEXYZ ciexyzBlue;
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CIEXYZ
    {
        public int ciexyzX;
        public int ciexyzY;
        public int ciexyzZ;
    }

}
